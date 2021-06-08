using Microsoft.EntityFrameworkCore;
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
                throw new KeyNotFoundException("No se encuentra el equipo especificado");
            Serie serie = _context.Series.Find(teamSerieDirector.SerieId, teamSerieDirector.SerieInitDate, teamSerieDirector.SerieEndDate);
            if (serie == null)
                throw new KeyNotFoundException("No se encuentra la serie especificada");
            Director director = _context.Directors.Find(teamSerieDirector.DirectorId);
            if (director == null)
                throw new KeyNotFoundException("No se encuentra el director especificado");
            _context.TeamsSeriesDirectors.Add(teamSerieDirector);
            _context.SaveChanges();
            return teamSerieDirector;
        }

        public List<Director> GetDirectorsOfTeamInSerie(Guid TeamId, Guid SerieId, DateTime initDate, DateTime endDate)
        {
            bool teamSD = _context.TeamsSeriesDirectors.Any(c => c.TeamSerieId == TeamId && c.SerieId == SerieId);
            if (!teamSD)
                throw new KeyNotFoundException("No se encuentran directores de este equipo en la serie especificada");

            return _context.TeamsSeriesDirectors.Include(c => c.Director).Where(c => c.SerieId == SerieId && c.SerieInitDate == initDate && c.SerieEndDate == endDate && c.TeamSerieId == TeamId).Select(c => c.Director).ToList();
        }

        public List<Director> GetTeamDirectors(Guid TeamId)
        {
            var aux = _context.TeamsSeriesDirectors.Any(c => c.TeamSerieId == TeamId);
            if (!aux)
                throw new KeyNotFoundException("No se encuentran directores de este equipo en la serie especificada");
            List<Director> directors = _context.TeamsSeriesDirectors.Include(c => c.Director).Where(c => c.TeamSerieId == TeamId).Select(c => c.Director).ToList();
            return directors;
        }

        public TeamSerieDirector GetTeamSerieDirector(Guid teamId, Guid SerieId, DateTime initDate, DateTime endDate, Guid DirectorId)
        {
            return _context.TeamsSeriesDirectors.Include(c => c.Serie).Include(c => c.Director).Include(c => c.TeamSerie).SingleOrDefault(c => c.DirectorId == DirectorId && c.SerieId == SerieId && c.SerieInitDate == initDate && c.SerieEndDate == endDate && c.TeamSerieId == teamId);
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
                throw new KeyNotFoundException("No se encuentra este director en la serie espeificada");
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
