using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IStartPositionPlayerSerieRepository
    {
        List<StartPositionPlayerSerie> GetStartPositionPlayersSeries();
        List<PositionPlayer> GetAllStartsTeam(Guid SerieId);
        StartPositionPlayerSerie GetStartPositionPlayerSerie(Guid SerieId, Guid PositionId);
        StartPositionPlayerSerie AddStartPositionPlayerSerie(StartPositionPlayerSerie startPositionPlayerSerie);
        StartPositionPlayerSerie UpdateStartPositionPlayerSerie(StartPositionPlayerSerie startPositionPlayerSerie);
        bool RemoveStartPositionPlayer(StartPositionPlayerSerie startPositionPlayerSerie);



    }
}
