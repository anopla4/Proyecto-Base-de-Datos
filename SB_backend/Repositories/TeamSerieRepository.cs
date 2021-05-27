using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class TeamSerieRepository : ITeamSerieRepository
    {
        private AppDBContext _context;
        public TeamSerieRepository(AppDBContext context)
        {
            _context = context;
        }
        public TeamSerie AddTeamSerie(TeamSerie teamSerie)
        {
            Team team = _context.Teams.Find(teamSerie.TeamId);
            if (team == null)
                return null;
            Serie serie = _context.Series.Find(teamSerie.SerieId);
            if (serie == null)
                return null;
            serie.NumberOfGames += 1;
            _context.Series.Update(serie);
            _context.TeamsSeries.Add(teamSerie);
            _context.SaveChanges();
            return teamSerie;
        }

        public List<TeamSerie> GetStanding(Guid SerieId)
        {
            return _context.TeamsSeries.Where(c => c.SerieId == SerieId).ToList();
        }

        public TeamSerie GetTeamSerie(Guid TeamId, Guid SerieId)
        {
            return _context.TeamsSeries.Include(c => c.Team).Include(c => c.Serie).SingleOrDefault(c => (c.TeamId == TeamId && c.SerieId == SerieId));
        }

        public List<TeamSerie> GetTeamsSeries()
        {
            return _context.TeamsSeries.Include(c => c.Team).Include(c => c.Serie).ToList();
        }

        public List<Serie> GetTeamWonSeries(Guid TeamId)
        {
            var someSerie = _context.TeamsSeries.Any(c => c.TeamId == TeamId);
            if(someSerie == false)
            {
                return null;
            }
            List<Serie> series = _context.TeamsSeries.Include(c => c.Serie).Where(c => c.TeamId == TeamId && c.FinalPosition == 1).Select(c => c.Serie).ToList();
            return series;
        }

        public bool RemoveTeamSerie(TeamSerie teamSerie)
        {
            var current_teamSerie = _context.TeamsSeries.Find(teamSerie.TeamId, teamSerie.SerieId);
            if(current_teamSerie != null)
            {
                _context.TeamsSeries.Remove(current_teamSerie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public TeamSerie UpdateTeamSerie(TeamSerie teamSerie)
        {
            var current_teamSerie = _context.TeamsSeries.Find(teamSerie.TeamId, teamSerie.SerieId);
            if (current_teamSerie != null)
            {
                current_teamSerie.FinalPosition = teamSerie.FinalPosition;
                current_teamSerie.WinnerGames = teamSerie.WinnerGames;
                current_teamSerie.LosserGames = teamSerie.LosserGames;
                _context.TeamsSeries.Update(current_teamSerie);
                _context.SaveChanges();
                return teamSerie;
            }
            return null;
        }
    }
}
