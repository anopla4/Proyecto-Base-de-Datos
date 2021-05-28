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
        List<Player> GetPlayersOfTeamInSerie(Guid TeamId, Guid SerieId);
        List<Player> GetTeamPlayers(Guid TeamId);
        TeamSeriePlayer GetTeamSeriePlayer(Guid SerieId, Guid PlayerId);
        TeamSeriePlayer AddTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer);
        TeamSeriePlayer UpdateTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer);
        bool RemoveTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer);

    }
}
