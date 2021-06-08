using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private AppDBContext _playerContext;

        public PlayerRepository(AppDBContext playerContext)
        {
            _playerContext = playerContext;
        }
        public Player AddPlayer(Player player, List<Position> positions)
        {
            player.Id = Guid.NewGuid();
            if (player.Current_TeamId != null && !_playerContext.Teams.Any(c => c.Id == player.Current_TeamId))
                throw new FormatException("No es válido el equipo actual del jugador.");
            player.Current_Team = _playerContext.Teams.Find(player.Current_TeamId);
            _playerContext.Players.Add(player);

            foreach(var position in positions)
                _playerContext.PlayerPosition.Add(new PlayerPosition() { PlayerId = player.Id, PositionId = position.Id });
            _playerContext.SaveChanges();
            return player;
        }

        public Player GetPlayer(Guid playerId)
        {
            var player = _playerContext.Players.Include(c => c.Current_Team).SingleOrDefault(c => c.Id == playerId);
            if (player == null)
                throw new KeyNotFoundException("No se encuentra el jugador especificado");
            return player;
        }

        public List<Position> GetPlayerPositions(Guid playerId)
        {
            if (!_playerContext.Players.Any(c => c.Id == playerId))
                throw new KeyNotFoundException("No se encuentra el jugador especificado");
            return _playerContext.PlayerPosition.Include(c => c.Position).Where(c => c.PlayerId == playerId).Select(c => c.Position).ToList();
        }

        public List<Player> GetPlayers()
        {
            return _playerContext.Players.Include(c => c.Current_Team).ToList();
        }

        public List<DTOPlayer> GetPlayersWithPositions()
        {
            var players = _playerContext.Players.Include(c => c.Current_Team).ToList();
            List<DTOPlayer> res = new List<DTOPlayer>();
            foreach (var player in players)
                res.Add(new DTOPlayer()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Current_Team = player.Current_Team,
                    Age = player.Age,
                    Year_Experience = player.Year_Experience,
                    DeffAverage = player.DeffAverage,
                    ERA = player.ERA,
                    Average = player.Average,
                    Hand = player.Hand,
                    ImgPath = player.ImgPath,
                    Positions = this.GetPlayerPositions(player.Id),
                    Teams = _playerContext.TeamsSeriesPlayers.Include(c => c.Team).Where(c => c.PlayerId == player.Id).Select(c => c.Team.Name).Distinct().ToList()
                });
            return res;
        }


        public List<Player> GetPitchers()
        {
            Position pitcher = _playerContext.Positions.SingleOrDefault(c => c.PositionName == "P");
            List<Player> pitchers = _playerContext.PlayerPosition.Include(c => c.Player).Where(c => c.PositionId == pitcher.Id).Select(c => c.Player).ToList();
            return pitchers;
        }

        public bool RemovePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Find(player.Id);

            if (curr_player != null)
            {
                foreach (var playerPosition in _playerContext.PlayerPosition.Where(c => c.PlayerId == player.Id))
                    _playerContext.PlayerPosition.Remove(playerPosition);
                foreach (var change in _playerContext.PlayersChangesGames.Where(x => (x.PlayerIdIn == player.Id) || (x.PlayerIdOut == player.Id)))
                    _playerContext.PlayersChangesGames.Remove(change);
                foreach (var game in _playerContext.Games.Where(x => (x.PitcherWinerId == player.Id) || (x.PitcherLoserId == player.Id)))
                    _playerContext.Games.Remove(game);
                foreach (var tsp in _playerContext.TeamsSeriesPlayers.Where(x => x.PlayerId == player.Id))
                    _playerContext.TeamsSeriesPlayers.Remove(tsp);
                foreach (var stp in _playerContext.StarPositionPlayersSeries.Where(x => x.PlayerId == player.Id))
                    _playerContext.StarPositionPlayersSeries.Remove(stp);
                _playerContext.Players.Remove(player);
                _playerContext.SaveChanges();
                return true;
            }
            throw new KeyNotFoundException("No se encuentra el jugador especificado");

        }

        public Player UpdatePlayer(Player player, List<Position> positions)
        {
            var curr_player = _playerContext.Players.Include(c => c.Current_Team).SingleOrDefault(c => c.Id == player.Id);

            if (curr_player != null)
            {
                curr_player.Age = player.Age;
                curr_player.Year_Experience = player.Year_Experience;
                curr_player.Current_Team = player.Current_Team;
                curr_player.Current_TeamId = player.Current_TeamId;
                curr_player.Current_Team = _playerContext.Teams.Find(player.Current_TeamId);
                curr_player.Average = player.Average;
                curr_player.DeffAverage = player.DeffAverage;
                if(player.ImgPath != null)
                    curr_player.ImgPath = player.ImgPath;
                Position pitcher = _playerContext.Positions.SingleOrDefault(c => c.PositionName == "P");
                if (_playerContext.PlayerPosition.Any(c => c.PlayerId == player.Id && c.PositionId == pitcher.Id))
                    curr_player.ERA = player.ERA;
                else
                    curr_player.ERA = null;
                _playerContext.Update(curr_player);

                foreach (var position in _playerContext.PlayerPosition.Where(c => c.PlayerId == player.Id))
                    _playerContext.PlayerPosition.Remove(position);
                foreach (var position in positions)
                    _playerContext.PlayerPosition.Add(new PlayerPosition() { PlayerId = player.Id, PositionId = position.Id });

                _playerContext.SaveChanges();
            }
            throw new KeyNotFoundException("No se encuentra el jugador especificado");

        }
    }
}
