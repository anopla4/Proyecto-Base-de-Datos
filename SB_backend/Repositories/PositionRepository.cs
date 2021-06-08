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

        public Position GetPosition(Guid Id)
        {
            var position = _context.Positions.SingleOrDefault(c => c.Id == Id);
            if (position == null)
                throw new KeyNotFoundException("No se encuentra la posición especificada");
            return position;
        }

        public List<Position> GetPositions()
        {
            return _context.Positions.ToList();
        }

        public bool RemovePosition(Position position)
        {
            Position current_position = _context.Positions.Find(position.PositionName);
            if(current_position != null)
            {
                _context.Positions.Remove(position);
                _context.SaveChanges();
                return true;
            }
            throw new KeyNotFoundException("No se encuentra la posición especificada");

        }

        public Position UpdatePosition(Position position)
        {
            var current_position = _context.Positions.Find(position.Id);
            if (current_position != null)
            {
                current_position.PositionName = position.PositionName;
                _context.Positions.Update(current_position);
                _context.SaveChanges();
            }
            throw new KeyNotFoundException("No se encuentra la posición especificada");
        }
    }
}
