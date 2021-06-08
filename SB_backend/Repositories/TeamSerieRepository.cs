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
                throw new KeyNotFoundException("No se encuentra el equipo especificado");
            Serie serie = _context.Series.Find(teamSerie.SerieId,teamSerie.SerieInitDate,teamSerie.SerieEndDate);
            if (serie == null)
                throw new KeyNotFoundException("No se encuentra la serie especificado");
            if (teamSerie.FinalPosition > serie.NumberOfTeams)
                throw new FormatException("No es válida la posición del equipo.");
            if (_context.TeamsSeries.Any(c => c.FinalPosition == teamSerie.FinalPosition && c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate))
                throw new FormatException("No es válida la posición del equipo.");
            if (teamSerie.FinalPosition == 1)
                serie.WinerId = teamSerie.TeamId;
            if (teamSerie.FinalPosition == serie.NumberOfTeams)
                serie.LoserId = teamSerie.TeamId;
            _context.Series.Update(serie);
            _context.TeamsSeries.Add(teamSerie);
            _context.SaveChanges();
            return teamSerie;
        }

        public List<TeamSerie> GetStanding(Guid SerieId, DateTime initDate, DateTime endDate)
        {
            return _context.TeamsSeries.Include(c => c.Team).Include(c=>c.Serie).Include(c=> c.Serie.CaracterSerie).Where(c => c.SerieId == SerieId && c.SerieInitDate == initDate && c.SerieEndDate == endDate).ToList();
        }

        public TeamSerie GetTeamSerie(Guid TeamId, Guid SerieId, DateTime initDate, DateTime endDate)
        {
            return _context.TeamsSeries.Include(c => c.Team).Include(c => c.Serie).SingleOrDefault(c => (c.TeamId == TeamId && c.SerieId == SerieId && c.SerieInitDate == initDate && c.SerieEndDate == endDate));
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
                throw new KeyNotFoundException("El equipo especificado no ha participado en ninguna serie");
            }
            List<Serie> series = _context.TeamsSeries.Include(c => c.Serie).Where(c => c.TeamId == TeamId && c.FinalPosition == 1).Select(c => c.Serie).ToList();
            return series;
        }

        public bool RemoveTeamSerie(TeamSerie teamSerie)
        {
            var current_teamSerie = _context.TeamsSeries.Find(teamSerie.TeamId, teamSerie.SerieId, teamSerie.SerieInitDate, teamSerie.SerieEndDate);
            if(current_teamSerie != null)
            {
                foreach (var change in _context.PlayersChangesGames.Include(c=>c.Game).Where(c => c.Game.SerieId == teamSerie.SerieId && c.Game.SerieInitDate == teamSerie.SerieInitDate && c.Game.SerieEndDate == teamSerie.SerieEndDate && (c.Game.LoserTeamId == teamSerie.TeamId || c.Game.WinerTeamId == teamSerie.TeamId)))
                    _context.PlayersChangesGames.Remove(change);
                foreach (var game in _context.Games.Where(c => c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate && (c.LoserTeamId == teamSerie.TeamId || c.WinerTeamId == teamSerie.TeamId)))
                    _context.Games.Remove(game);
                var teamPlayerIDs = _context.TeamsSeriesPlayers.Where(c => c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate && c.TeamId == teamSerie.TeamId).Select(c => c.PlayerId).ToList();
                foreach (var stp in _context.StarPositionPlayersSeries.Where(c => c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate && teamPlayerIDs.Contains(c.PlayerId)))
                    _context.StarPositionPlayersSeries.Remove(stp);
                foreach (var tsp in _context.TeamsSeriesPlayers.Where(c => c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate && c.TeamId == teamSerie.TeamId))
                    _context.TeamsSeriesPlayers.Remove(tsp);
                foreach (var tsd in _context.TeamsSeriesDirectors.Where(c => c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate && c.TeamSerieId == teamSerie.TeamId))
                    _context.TeamsSeriesDirectors.Remove(tsd);

                _context.TeamsSeries.Remove(current_teamSerie);
                _context.SaveChanges();
                return true;
            }
            throw new KeyNotFoundException("No se encuentra el equipo en el standing de la serie especificada");
        }

        public TeamSerie UpdateTeamSerie(TeamSerie teamSerie)
        {
            var current_teamSerie = _context.TeamsSeries.Find(teamSerie.TeamId, teamSerie.SerieId, teamSerie.SerieInitDate, teamSerie.SerieEndDate);
            if (current_teamSerie != null)
            {
                Serie serie = _context.Series.Find(teamSerie.SerieId, teamSerie.SerieInitDate, teamSerie.SerieEndDate);
                if (serie == null)
                    throw new KeyNotFoundException("No se encuentra la serie especificado");
                if (teamSerie.FinalPosition > serie.NumberOfTeams)
                    throw new FormatException("No es válida la posición del equipo.");
                if (_context.TeamsSeries.Any(c => c.FinalPosition == teamSerie.FinalPosition && c.SerieId == teamSerie.SerieId && c.SerieInitDate == teamSerie.SerieInitDate && c.SerieEndDate == teamSerie.SerieEndDate))
                    throw new FormatException("No es válida la posición del equipo.");
                if (teamSerie.FinalPosition == 1)
                    serie.WinerId = teamSerie.TeamId;
                if (teamSerie.FinalPosition == serie.NumberOfTeams)
                    serie.LoserId = teamSerie.TeamId;
                current_teamSerie.FinalPosition = teamSerie.FinalPosition;
                current_teamSerie.WonGames = teamSerie.WonGames;
                current_teamSerie.LostGames = teamSerie.LostGames;
                 _context.TeamsSeries.Update(current_teamSerie);
                _context.SaveChanges();
                return teamSerie;
            }
            throw new KeyNotFoundException("No se encuentra el equipo en el standing de la serie especificada");
        }
    }
}
