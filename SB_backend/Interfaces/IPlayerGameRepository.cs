using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IPlayerGameRepository
    {
        List<PlayerGame> GetPlayersGames();
        List<PlayerGame> GetPlayersInGame(Guid gameId);
        List<PlayerPosition> GetPlayersInGameWinerTeam(Guid gameId);
        List<PlayerPosition> GetPlayersInGameLoserTeam(Guid gameId);
        PlayerGame GetPlayerInGame(Guid gameId, Guid playerId, Guid positionId);
        PlayerGame AddPlayerInGame(PlayerGame playerGame);
        bool DeletePlayerInGame(PlayerGame playerGame);


    }
}
