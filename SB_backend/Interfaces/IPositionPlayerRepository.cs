using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IPositionPlayerRepository
    {
        List<PositionPlayer> GetPositionPlayers();
        PositionPlayer GetPositionPlayer(Guid Playerid, Guid PositionId);
        List<Position> GetPlayerPositions(Guid PlayerId);

        PositionPlayer AddPositionPlayer(PositionPlayer player);

        bool RemovePositionPlayer(PositionPlayer player);

        PositionPlayer UpdatePositionPlayer(PositionPlayer player);
    }
}
