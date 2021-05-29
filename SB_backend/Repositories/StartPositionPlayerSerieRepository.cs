using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;

namespace SB_backend.Repositories
{
    public class StartPositionPlayerSerieRepository : IStartPositionPlayerSerieRepository
    {
        private AppDBContext _context;
        public StartPositionPlayerSerieRepository(AppDBContext context)
        {
            _context = context;
        }
        public StartPositionPlayerSerie AddStartPositionPlayerSerie(StartPositionPlayerSerie startPositionPlayerSerie)
        {
            var flagSerie = _context.Series.Any(c => c.Id == startPositionPlayerSerie.SerieId && c.InitDate == startPositionPlayerSerie.SerieInitDate && c.EndDate == startPositionPlayerSerie.SerieEndDate);
            if (!flagSerie)
                return null;
            var flagPositionPlayer = _context.PositionPlayers.Any(c => c.PlayerId == startPositionPlayerSerie.PlayerId && c.PositionId == startPositionPlayerSerie.PositionId);
            if (!flagPositionPlayer)
                return null;
            _context.StartPositionPlayersSeries.Add(startPositionPlayerSerie);
            _context.SaveChanges();
            return startPositionPlayerSerie;
        }

        public List<PositionPlayer> GetAllStartsTeam(Guid SerieId)
        {
            if(!_context.StartPositionPlayersSeries.Any(c => c.SerieId == SerieId))
            {
                return null;
            }
            return _context.StartPositionPlayersSeries.Include(c => c.PositionPlayer).Where(c => c.SerieId == SerieId).Select(c => c.PositionPlayer).ToList();
        }

        public StartPositionPlayerSerie GetStartPositionPlayerSerie(Guid SerieId, Guid PositionId)
        {
            var startPosPlayer = _context.StartPositionPlayersSeries.Include(c => c.PositionPlayer).Include(c => c.Serie).SingleOrDefault(c => c.SerieId == SerieId && c.PositionId == PositionId);
            if (startPosPlayer == null)
                return null;
            return startPosPlayer;
        }

        public List<StartPositionPlayerSerie> GetStartPositionPlayersSeries()
        {
            return _context.StartPositionPlayersSeries.ToList();
        }

        public bool RemoveStartPositionPlayer(StartPositionPlayerSerie startPositionPlayerSerie)
        {
            var currStartPosPlayer = _context.StartPositionPlayersSeries.SingleOrDefault(c => c.SerieId == startPositionPlayerSerie.SerieId && c.PositionId == startPositionPlayerSerie.PositionId);
            if(currStartPosPlayer == null)
                return false;
            _context.StartPositionPlayersSeries.Remove(currStartPosPlayer);
            _context.SaveChanges();
            return true;

        }

        public StartPositionPlayerSerie UpdateStartPositionPlayerSerie(StartPositionPlayerSerie startPositionPlayerSerie)
        {
            var currStartPosPlayer = _context.StartPositionPlayersSeries.SingleOrDefault(c => c.SerieId == startPositionPlayerSerie.SerieId && c.PositionId == startPositionPlayerSerie.PositionId);
            if (currStartPosPlayer == null)
                return null;
            currStartPosPlayer.PlayerId = startPositionPlayerSerie.PlayerId;
            _context.StartPositionPlayersSeries.Update(currStartPosPlayer);
            _context.SaveChanges();
            return currStartPosPlayer;
        }
    }
}
