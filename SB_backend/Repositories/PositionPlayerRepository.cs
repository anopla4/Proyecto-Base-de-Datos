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

        public List<Position> GetPlayerPositions(Guid PlayerId)
        {
            bool flag = _context.Players.Any(c => c.Id == PlayerId);
            if (!flag)
                return null;
            var positions = _context.PositionPlayers.Include(c => c.Position).Where(c => c.PlayerId == PlayerId).Select(c => c.Position).ToList();
            return positions;
        }

        public PositionPlayer GetPositionPlayer(Guid PlayerId,Guid PositionId)
        {
            return _context.PositionPlayers.Include(c => c.Player).Include(c => c.Position).SingleOrDefault(c => c.PlayerId == PlayerId && c.PositionId == PositionId);
        }

        public List<PositionPlayer> GetPositionPlayers()
        {
            return _context.PositionPlayers.Include(c => c.Player).Include(c => c.Position).ToList();
        }

        public bool RemovePositionPlayer(PositionPlayer player)
        {
            var curr_player = _context.PositionPlayers.SingleOrDefault(c => c.PlayerId == player.PlayerId && c.PositionId == player.PositionId);

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
            var curr_player = _context.PositionPlayers.Include(c => c.Position).SingleOrDefault(c => c.PlayerId == player.PlayerId && c.PositionId == player.PositionId);
            if (curr_player == null)
                return null;
            curr_player.Position_Average = player.Position_Average;
            _context.PositionPlayers.Update(curr_player);
            _context.SaveChanges();
            return curr_player;
        }
    }
}
