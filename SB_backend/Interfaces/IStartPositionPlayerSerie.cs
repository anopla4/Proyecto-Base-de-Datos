using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IStartPositionPlayerSerie
    {
        List<StartPositionPlayerSerie> GetStartPositionPlayersSeries();
        List<PositionPlayer> GetAllStartsTeam(Guid SerieId);
        StartPositionPlayerSerie GetStartPositionPlayerSerie(Guid SerieId, Guid PositionId);
        StartPositionPlayerSerie AddStartPositionPlayerSerie(Guid SerieId, Guid PlayerId, Guid PositionId, StartPositionPlayerSerie startPositionPlayerSerie);
        StartPositionPlayerSerie UpdateStartPositionPlayerSerie(Guid SerieId, Guid PlayerId, Guid PositionId, StartPositionPlayerSerie startPositionPlayerSerie);




    }
}
