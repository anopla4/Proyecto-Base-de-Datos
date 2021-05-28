﻿using Microsoft.EntityFrameworkCore;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SB_backend.Interfaces;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class TeamSerieDirectorRepository: ITeamSerieDirectorRepository
    {
        private AppDBContext _context;
        public TeamSerieDirectorRepository(AppDBContext context)
        {
            _context = context;
        }
        public TeamSerieDirector AddTeamSerieDirector(TeamSerieDirector teamSerieDirector)
        {
            Team team = _context.Teams.Find(teamSerieDirector.TeamSerieId);
            if (team == null)
                return null;
            Serie serie = _context.Series.Find(teamSerieDirector.SerieId);
            if (serie == null)
                return null;
            Director director = _context.Directors.Find(teamSerieDirector.DirectorId);
            if (director == null)
                return null;
            _context.TeamsSeriesDirectors.Add(teamSerieDirector);
            _context.SaveChanges();
            return teamSerieDirector;
        }

        public List<Director> GetDirectorsOfTeamInSerie(Guid TeamId, Guid SerieId)
        {
            bool teamSD = _context.TeamsSeriesDirectors.Any(c => c.TeamSerieId == TeamId && c.SerieId == SerieId);
            if (!teamSD)
                return null;
            return _context.TeamsSeriesDirectors.Include(c => c.Director).Where(c => c.SerieId == SerieId && c.TeamSerieId == TeamId).Select(c => c.Director).ToList();
        }

        public List<Director> GetTeamDirectors(Guid TeamId)
        {
            var aux = _context.TeamsSeriesDirectors.Any(c => c.TeamSerieId == TeamId);
            if (!aux)
                return null;
            List<Director> directors = _context.TeamsSeriesDirectors.Include(c => c.Director).Where(c => c.TeamSerieId == TeamId).Select(c => c.Director).ToList();
            return directors;
        }

        public TeamSerieDirector GetTeamSerieDirector(Guid SerieId, Guid DirectorId)
        {
            return _context.TeamsSeriesDirectors.Include(c => c.Serie).Include(c => c.Director).Include(c => c.TeamSerie).SingleOrDefault(c => c.DirectorId == DirectorId && c.SerieId == SerieId);
        }


        public List<TeamSerieDirector> GetTeamsSeriesDirectors()
        {
            return _context.TeamsSeriesDirectors.ToList();
        }

        public bool RemoveTeamSerieDirector(TeamSerieDirector teamSerieDirector)
        {
            var currTeamSerieDirector = _context.TeamsSeriesDirectors.SingleOrDefault(c => c.DirectorId == teamSerieDirector.DirectorId && c.SerieId == teamSerieDirector.SerieId);
            if (currTeamSerieDirector == null)
            {
                return false;
            }
            _context.TeamsSeriesDirectors.Remove(currTeamSerieDirector);
            _context.SaveChanges();
            return true;
        }

        public TeamSerieDirector UpdateTeamSerieDirector(TeamSerieDirector teamSerieDirector)
        {
            var currTeamSerieDirector = _context.TeamsSeriesDirectors.SingleOrDefault(c => c.DirectorId == teamSerieDirector.DirectorId && c.SerieId == teamSerieDirector.SerieId);
            if (currTeamSerieDirector == null)
            {
                return null;
            }
            currTeamSerieDirector.TeamSerieId = teamSerieDirector.TeamSerieId;
            _context.TeamsSeriesDirectors.Update(currTeamSerieDirector);
            _context.SaveChanges();
            return currTeamSerieDirector;
        }
    }
}
