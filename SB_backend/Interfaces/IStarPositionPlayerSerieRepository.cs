using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IStarPositionPlayerSerieRepository
    {
        List<StarPositionPlayerSerie> GetStarPositionPlayersSeries();
        List<StarPositionPlayerSerie> GetAllStarsTeam(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate);
        StarPositionPlayerSerie GetStarPositionPlayerSerie(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate, Guid PlayerPositionId);
        StarPositionPlayerSerie AddStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie);
        StarPositionPlayerSerie UpdateStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie);
        bool RemoveStarPositionPlayer(StarPositionPlayerSerie starPositionPlayerSerie);
    }
}
