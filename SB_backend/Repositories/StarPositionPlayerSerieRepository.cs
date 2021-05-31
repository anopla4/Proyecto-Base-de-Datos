using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;

namespace SB_backend.Repositories
{
    public class StarPositionPlayerSerieRepository : IStarPositionPlayerSerieRepository
    {
        private AppDBContext _context;
        public StarPositionPlayerSerieRepository(AppDBContext context)
        {
            _context = context;
        }
        public StarPositionPlayerSerie AddStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var flagSerie = _context.Series.Any(c => c.Id == starPositionPlayerSerie.SerieId && c.InitDate == starPositionPlayerSerie.SerieInitDate && c.EndDate == starPositionPlayerSerie.SerieEndDate);
            if (!flagSerie)
                return null;
            Position position = _context.Positions.Find(starPositionPlayerSerie.PlayerPositionId);
            if (position == null)
                return null;
            var flagPlayer = _context.Players.Any(c => c.Id == starPositionPlayerSerie.PlayerId && c.PositionId == position.Id);
            if (!flagPlayer)
                return null;
            if (_context.StarPositionPlayersSeries.Any(c => c.SerieId == starPositionPlayerSerie.SerieId && c.SerieInitDate == starPositionPlayerSerie.SerieInitDate && c.SerieEndDate == starPositionPlayerSerie.SerieEndDate && c.PlayerPositionId == starPositionPlayerSerie.PlayerPositionId))
                return null;
            _context.StarPositionPlayersSeries.Add(starPositionPlayerSerie);
            _context.SaveChanges();
            return starPositionPlayerSerie;
        }

        public List<StarPositionPlayerSerie> GetAllStarsTeam(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate)
        {
            if (!_context.StarPositionPlayersSeries.Any(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate)) 
            {
                return null;
            }
            return _context.StarPositionPlayersSeries.Include(c => c.Player).Include(c => c.Player.Position).Where(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate).ToList();
        }

        public StarPositionPlayerSerie GetStarPositionPlayerSerie(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate, Guid PositionId)
        {
            var starPosPlayer = _context.StarPositionPlayersSeries.Include(c => c.Player).Include(c => c.Player.Position).Include(c => c.Serie).SingleOrDefault(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate && c.PlayerPositionId == PositionId);
            if (starPosPlayer == null)
                return null;
            return starPosPlayer;
        }

        public List<StarPositionPlayerSerie> GetStarPositionPlayersSeries()
        {
            return _context.StarPositionPlayersSeries.ToList();
        }

        public bool RemoveStarPositionPlayer(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var currStarPosPlayer = _context.StarPositionPlayersSeries.SingleOrDefault(c => c.SerieId == starPositionPlayerSerie.SerieId && c.SerieInitDate == starPositionPlayerSerie.SerieInitDate && c.SerieEndDate == starPositionPlayerSerie.SerieEndDate && c.PlayerPositionId == starPositionPlayerSerie.PlayerPositionId);
            if(currStarPosPlayer == null)
                return false;
            _context.StarPositionPlayersSeries.Remove(currStarPosPlayer);
            _context.SaveChanges();
            return true;

        }

        public StarPositionPlayerSerie UpdateStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var currStarPosPlayer = _context.StarPositionPlayersSeries.SingleOrDefault(c => c.SerieId == starPositionPlayerSerie.SerieId && c.SerieInitDate == starPositionPlayerSerie.SerieInitDate && c.SerieEndDate == starPositionPlayerSerie.SerieEndDate && c.PlayerPositionId == starPositionPlayerSerie.PlayerPositionId);
            if (currStarPosPlayer == null)
                return null;
            currStarPosPlayer.PlayerId = starPositionPlayerSerie.PlayerId;
            _context.StarPositionPlayersSeries.Update(currStarPosPlayer);
            _context.SaveChanges();
            return currStarPosPlayer;
        }
    }
}
