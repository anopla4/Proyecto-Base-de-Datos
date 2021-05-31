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
        public Player AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid();
            if (player.Current_TeamId != null && !_playerContext.Teams.Any(c => c.Id == player.Current_TeamId))
                return null;
            player.Current_Team = _playerContext.Teams.Find(player.Current_TeamId);
            _playerContext.Players.Add(player);
            _playerContext.SaveChanges();
            return player;
        }

        public Player GetPlayer(Guid id, Guid PositionId)
        {
            //var player = _playerContext.Players.Find(id);
            var player = _playerContext.Players.Include(c => c.Current_Team).SingleOrDefault(c => c.Id == id && c.PositionId == PositionId);
            return player;
        }

        public List<Position> GetPlayerPositions(Guid playerId)
        {
            if (!_playerContext.Players.Any(c => c.Id == playerId))
                return null;
            return _playerContext.Players.Include(c => c.Position).Where(c => c.Id == playerId).Select(c => c.Position).ToList();
        }

        public List<Player> GetPlayers()
        {
            return _playerContext.Players.Include(c => c.Current_Team).Include(c => c.Position).ToList();
        }

        public List<Player> GetPitchers()
        {
            Position pitcher = _playerContext.Positions.SingleOrDefault(c => c.PositionName == "P");
            List<Player> pitchers = _playerContext.Players.Where(c => c.PositionId == pitcher.Id).ToList();
            return pitchers;
        }

        public bool RemovePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Find(player.Id, player.PositionId);

            if (curr_player != null)
            {
                foreach (var change in _playerContext.PlayersChangesGames.Where(x => (x.PlayerInId == player.Id && x.PlayerInPositionId == player.PositionId) || x.PlayerInPositionId == player.PositionId))
                    _playerContext.PlayersChangesGames.Remove(change);
                foreach (var game in _playerContext.Games.Where(x => (x.PitcherWinerId == player.Id && x.PitcherWinerPositionId == player.PositionId) || (x.PitcherLoserId == player.Id && x.PitcherLoserPositionId == player.PositionId)))
                    _playerContext.Games.Remove(game);
                if(!_playerContext.Players.Any(c => c.Id == player.Id && c.PositionId != player.PositionId))
                    foreach (var tsp in _playerContext.TeamsSeriesPlayers.Where(x => x.PlayerId == player.Id))
                        _playerContext.TeamsSeriesPlayers.Remove(tsp);
                    foreach (var stp in _playerContext.StarPositionPlayersSeries.Where(x => x.PlayerId == player.Id))
                        _playerContext.StarPositionPlayersSeries.Remove(stp);
                _playerContext.Players.Remove(player);
                _playerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Player UpdatePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Include(c => c.Current_Team).Include(c => c.Position).SingleOrDefault(c => c.Id == player.Id && c.PositionId == player.PositionId);

            if (curr_player != null)
            {
                curr_player.Age = player.Age;
                curr_player.Year_Experience = player.Year_Experience;
                curr_player.Current_Team = player.Current_Team;
                curr_player.Current_TeamId = player.Current_TeamId;
                curr_player.Average = player.Average;
                curr_player.DeffAverage = player.DeffAverage;
                //curr_player.ERA = player.ERA;
                Position pitcher = _playerContext.Positions.SingleOrDefault(c => c.PositionName == "P");
                if (player.PositionId ==  pitcher.Id)
                    curr_player.ERA = player.ERA;
                else
                    curr_player.ERA = null;
                _playerContext.Update(curr_player);
                _playerContext.SaveChanges();
            }
            return curr_player;
        }
    }
}
