using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class PositionPlayerRepository : IPositionPlayerRepository
    {
        private AppDBContext _context;
        public PositionPlayerRepository(AppDBContext context)
        {
            _context = context;
        }
        public PositionPlayer AddPositionPlayer(PositionPlayer player)
        {
            _context.PositionPlayers.Add(player);
            return player;
        }

        public PositionPlayer GetPositionPlayer(Guid id)
        {
            return _context.PositionPlayers.Include(c => c.Player).Include(c => c.Position).SingleOrDefault(c => c.PlayerId == id);
        }

        public List<PositionPlayer> GetPositionPlayers()
        {
            return _context.PositionPlayers.Include(c => c.Player).Include(c => c.Position).ToList();
        }

        public bool RemovePositionPlayer(PositionPlayer player)
        {
            var curr_player = _context.PositionPlayers.Find(player.PlayerId);

            if (curr_player != null)
            {
                _context.PositionPlayers.Remove(player);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public PositionPlayer UpdatePositionPlayer(PositionPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
