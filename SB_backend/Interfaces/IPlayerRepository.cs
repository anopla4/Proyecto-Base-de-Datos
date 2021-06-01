using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SB_backend.Models;

namespace SB_backend.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayers();
        Player GetPlayer(Guid playerId);
        Player AddPlayer(Player player);
        List<Position> GetPlayerPositions(Guid playerId);
        List<Player> GetPitchers();
        bool RemovePlayer(Player player);
        Player UpdatePlayer(Player player);
    }
}
