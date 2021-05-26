using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private AppDBContext _context;
        public PositionRepository(AppDBContext context)
        {
            _context = context;
        }
        public Position AddPosition(Position position)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
            return position;
        }

        public Position GetPosition(string Position_Name)
        {
            return _context.Positions.SingleOrDefault(c => c.Position_Name == Position_Name);
        }

        public Position GetPosition(Guid Id)
        {
            return _context.Positions.SingleOrDefault(c => c.Id == Id);
        }

        public List<Position> GetPositions()
        {
            return _context.Positions.ToList();
        }

        public bool RemovePosition(Position position)
        {
            Position current_position = _context.Positions.Find(position.Position_Name);
            if(current_position != null)
            {
                _context.Remove(position);
                _context.SaveChanges();
                return true;
            }
            return false;
            
        }

        public Position UpdatePosition(Position position)
        {
            var current_position = _context.Positions.Find(position.Id);
            if (current_position != null)
            {
                current_position.Position_Name = position.Position_Name;
                _context.Positions.Update(current_position);
                _context.SaveChanges();
            }
            return current_position;
        }
    }
}
