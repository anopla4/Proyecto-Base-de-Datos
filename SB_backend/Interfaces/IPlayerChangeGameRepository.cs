using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IPlayerChangeGameRepository
    {
        List<PlayerChangeGame> GetPlayersChangesGames();
        List<PlayerChangeGame> GetPlayersChangesInGame(Guid GameId);
        List<PlayerChangeGame> GetPlayersChangesInGameWinerTeam(Guid GameId);
        List<PlayerChangeGame> GetPlayersChangesInGameLoserTeam(Guid GameId);
        PlayerChangeGame AddChangeInGame(PlayerChangeGame PlayerChangeGame);
        bool RemoveChangeInGame(Guid GameId, Guid PlayerInId, Guid PositionIdIn, Guid PlayerOutId, Guid PositionIdOut);
    }
}
