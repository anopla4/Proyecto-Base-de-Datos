using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IPositionRepository
    {
        List<Position> GetPositions();
        Position GetPosition(Guid Id);
        Position AddPosition(Position position);
        Position UpdatePosition(Position position);
        bool RemovePosition(Position position);
        
    }
}
