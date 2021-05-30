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

        public List<Player> GetPlayers()
        {
            return _playerContext.Players.Include(c => c.Current_Team).ToList();
        }

        public bool RemovePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Find(player.Id);

            if (curr_player != null)
            {
                _playerContext.Players.Remove(player);
                _playerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Player UpdatePlayer(Player player)
        {
            var curr_player = _playerContext.Players.Include(c => c.Current_Team).SingleOrDefault(c => c.Id == player.Id);

            if (curr_player != null)
            {
                //ver esto bien
                curr_player.Age = player.Age;
                curr_player.Year_Experience = player.Year_Experience;
                curr_player.Current_Team = player.Current_Team;
                curr_player.Current_TeamId = curr_player.Current_TeamId;
                _playerContext.Update(curr_player);
                _playerContext.SaveChanges();
            }
            return player;
        }
    }
}
