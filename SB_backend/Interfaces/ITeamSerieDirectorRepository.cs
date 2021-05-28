﻿using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ITeamSerieDirectorRepository
    {
        List<TeamSerieDirector> GetTeamsSeriesDirectors();
        List<Director> GetDirectorsOfTeamInSerie(Guid TeamId, Guid SerieId);
        List<Director> GetTeamDirectors(Guid TeamId);
        TeamSerieDirector GetTeamSerieDirector(Guid SerieId, Guid DirectorId);
        TeamSerieDirector AddTeamSerieDirector(TeamSerieDirector teamSerieDirector);
        TeamSerieDirector UpdateTeamSerieDirector(TeamSerieDirector teamSerieDirector);
        bool RemoveTeamSerieDirector(TeamSerieDirector teamSerieDirector);
    }
}
