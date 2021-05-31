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
        List<PlayerGame> GetPlayersInGame(Guid GameId);
        List<PlayerGame> GetPlayersInGameWinerTeam(Guid GameId);
        List<PlayerGame> GetPlayersInGameLoserTeam(Guid GameId);
        PlayerGame GetPlayerInGame(Guid GameId, Guid PlayerId, Guid PlayerPositionId);
        PlayerGame AddPositionPlayerInGame(PlayerGame PlayerGame);
        PlayerGame UpdatePlayerInGameWinerTeam(PlayerGame PlayerGame);
        PlayerGame UpdatePlayerInGameLoserTeam(PlayerGame PlayerGame);
        bool DeletePlayerInGame(PlayerGame PlayerGame);


    }
}
