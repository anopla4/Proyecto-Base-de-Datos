using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ITeamSeriePlayerRepository
    {
        List<TeamSeriePlayer> GetTeamsSeriesPlayers();
        List<Player> GetPlayersOfTeamInSerie(Guid TeamId, Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate);
        List<Player> GetPlayersInSerie(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate);
        List<Player> GetTeamPlayers(Guid TeamId);
        List<Team> GetPlayerTeams(Guid PlayerId);
        List<Player> GetPitchersTeamInSerie(Guid teamId, Guid SerieId, DateTime InitDate, DateTime EndDate);
        TeamSeriePlayer GetTeamSeriePlayer(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate, Guid PlayerId);
        TeamSeriePlayer AddTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer);
        TeamSeriePlayer UpdateTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer);
        bool RemoveTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer);

    }
}
