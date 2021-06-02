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
        Player AddPlayer(Player player, List<Position> positions);
        List<Position> GetPlayerPositions(Guid playerId);
        List<DTOPlayer> GetPlayersWithPositions();
        List<Player> GetPitchers();
        bool RemovePlayer(Player player);
        Player UpdatePlayer(Player player, List<Position> positions);
    }
}
