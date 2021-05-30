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
            if (!_playerContext.Teams.Any(c => c.Id == player.Current_TeamId))
                return null;
            player.Current_Team = _playerContext.Teams.Find(player.Current_TeamId);
            _playerContext.Players.Add(player);
            _playerContext.SaveChanges();
            return player;
        }

        public Player GetPlayer(Guid id)
        {
            //var player = _playerContext.Players.Find(id);
            var player = _playerContext.Players.Include(c => c.Current_Team).SingleOrDefault(c => c.Id == id);
            return player;
        }

        public List<Position> GetPlayerPositions(Guid playerId)
        {
            if (!_playerContext.Players.Any(c => c.Id == playerId))
                return null;
            return _playerContext.Players.Include(c => c.Positions).SingleOrDefault(c => c.Id == playerId).Positions;
        }

        public List<Player> GetPlayers()
        {
            return _playerContext.Players.Include(c => c.Current_Team).Include(c => c.Positions).ToList();
        }

        public List<Player> GetPitchers()
        {
            Position pitcher = _playerContext.Positions.SingleOrDefault(c => c.PositionName == "P");
            List<Player> pitchers = _playerContext.Players.Include(c => c.Positions).Where(c => c.Positions.Contains(pitcher)).ToList();
            return pitchers;
        }

        public bool RemovePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Find(player.Id);

            if (curr_player != null)
            {
                //Agregar Validaciones
                _playerContext.Players.Remove(player);
                _playerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Player UpdatePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Include(c => c.Current_Team).Include(c => c.Positions).SingleOrDefault(c => c.Id == player.Id);

            if (curr_player != null)
            {
                curr_player.Age = player.Age;
                curr_player.Year_Experience = player.Year_Experience;
                curr_player.Current_Team = player.Current_Team;
                curr_player.Current_TeamId = player.Current_TeamId;
                curr_player.Positions = player.Positions;
                curr_player.Average = player.Average;
                curr_player.DeffAverage = player.DeffAverage;
                curr_player.ERA = player.ERA;
                Position pitcher = _playerContext.Positions.SingleOrDefault(c => c.PositionName == "P");
                if (player.Positions.Contains(pitcher))
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
