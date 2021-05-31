﻿using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private AppDBContext _context;

        public SerieRepository(AppDBContext context)
        {
            _context = context;
        }
        public Serie AddSerie(Serie serie)
        {
            serie.Id = Guid.NewGuid();
            _context.Series.Add(serie);
            _context.SaveChanges();
            return serie;
        }

        public Serie GetSerie(Guid id, DateTime initDate, DateTime endDate)
        {
            //return _context.Series.Include(c => c.CaracterSerie).SingleOrDefault(c => c.Id == id);
            return _context.Series.Find(id, initDate, endDate);
        }

        public List<Serie> GetSeries()
        {
            return _context.Series.Include(c => c.CaracterSerie).ToList();
        }

        public bool RemoveSerie(Guid Id, DateTime initDate, DateTime endDate)
        {
            var curr_serie = _context.Series.Find(Id, initDate, endDate);

            if (curr_serie != null)
            {
                foreach (var change in _context.PlayersChangesGames.Where(c => c.GameSerieId == Id && c.GameSerieInitDate == initDate && c.GameSerieEndDate == endDate))
                    _context.PlayersChangesGames.Remove(change);
                foreach (var playerGame in _context.PlayersGames.Where(c => c.gameSerieId == Id && c.gameSerieInitDate == initDate && c.gameSerieEndDate == endDate))
                    _context.PlayersGames.Remove(playerGame);
                foreach (var playerGame in _context.Games.Where(c => c.SerieId == Id && c.SerieInitDate == initDate && c.SerieEndDate == endDate))
                    _context.Games.Remove(playerGame);
                foreach (var ts in _context.TeamsSeries.Where(c => c.SerieId == Id && c.SerieInitDate == initDate && c.SerieEndDate == endDate))
                    _context.TeamsSeries.Remove(ts);
                foreach (var tps in _context.TeamsSeriesPlayers.Where(c => c.SerieId == Id && c.SerieInitDate == initDate && c.SerieEndDate == endDate))
                    _context.TeamsSeriesPlayers.Remove(tps);
                foreach (var tds in _context.TeamsSeriesDirectors.Where(c => c.SerieId == Id && c.SerieInitDate == initDate && c.SerieEndDate == endDate))
                    _context.TeamsSeriesDirectors.Remove(tds);
                foreach (var stp in _context.StarPositionPlayersSeries.Where(c => c.SerieId == Id && c.SerieInitDate == initDate && c.SerieEndDate == endDate))
                    _context.StarPositionPlayersSeries.Remove(stp);


                _context.Series.Remove(curr_serie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Serie UpdateSerie(Serie serie)
        {
            var curr_serie = _context.Series.Find(serie.Id, serie.InitDate, serie.EndDate);

            if (curr_serie != null)
            {
                curr_serie.Name = serie.Name;
                curr_serie.CaracterId = serie.CaracterId;
                curr_serie.WinerId = serie.WinerId;
                curr_serie.LoserId = serie.LoserId;
                curr_serie.NumberOfGames = serie.NumberOfGames;
                curr_serie.NumberOfTeams = serie.NumberOfTeams;

                _context.Series.Update(curr_serie);
                _context.SaveChanges();
                return curr_serie;
            }
            return null;
        }
    }
}
