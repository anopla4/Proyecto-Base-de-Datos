using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ITeamSerieRepository
    {
        List<TeamSerie> GetTeamsSeries();
        List<TeamSerie> GetStanding(Guid SerieId);
        TeamSerie GetTeamSerie(Guid TeamId,Guid SerieId);
        List<Serie> GetTeamWonSeries(Guid TeamId);
        TeamSerie UpdateTeamSerie(TeamSerie teamSerie);
        TeamSerie AddTeamSerie(TeamSerie teamSerie);
        bool RemoveTeamSerie(TeamSerie teamSerie);
    }
}
