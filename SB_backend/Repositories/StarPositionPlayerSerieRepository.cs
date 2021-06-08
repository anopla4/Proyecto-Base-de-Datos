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
            var flagSerie = _context.Series.Any(c => c.Id == starPositionPlayerSerie.SerieId 
            && c.InitDate == starPositionPlayerSerie.SerieInitDate 
            && c.EndDate == starPositionPlayerSerie.SerieEndDate);
            if (!flagSerie)
                throw new KeyNotFoundException("No se encuentra la serie especificada");

            var flagPlayerPosition = _context.PlayerPosition.Any(c => c.PlayerId == starPositionPlayerSerie.PlayerId && c.PositionId == starPositionPlayerSerie.PositionId);
            if (!flagPlayerPosition)
                throw new FormatException("No es válida la posición para el jugador especificado");

            if (_context.StarPositionPlayersSeries.Any(c => c.SerieId == starPositionPlayerSerie.SerieId && c.SerieInitDate == starPositionPlayerSerie.SerieInitDate && c.SerieEndDate == starPositionPlayerSerie.SerieEndDate && (c.PlayerId == starPositionPlayerSerie.PlayerId || c.PositionId == starPositionPlayerSerie.PositionId)))
                throw new Exception("Ya se incluyo un jugador en esta posición en el equipo todos estrellas de la serie especificada");
            _context.StarPositionPlayersSeries.Add(starPositionPlayerSerie);
            _context.SaveChanges();
            return starPositionPlayerSerie;
        }

        public List<StarPositionPlayerSerie> GetAllStarsTeam(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate)
        {
            if (!_context.StarPositionPlayersSeries.Any(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate)) 
            {
                throw new Exception("No se ha ingresado el equipo todos estrellas correspondiente a la serie especificada");
            }
            return _context.StarPositionPlayersSeries.Include(c => c.Player).Include(c => c.Player.Position).Where(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate).ToList();
        }

        public StarPositionPlayerSerie GetStarPositionPlayerSerie(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate, Guid PositionId)
        {
            var starPosPlayer = _context.StarPositionPlayersSeries.Include(c => c.Player).Include(c => c.Player.Position).Include(c => c.Serie).SingleOrDefault(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate && c.PositionId == PositionId);
            if (starPosPlayer == null)
                throw new Exception("No se ha ingresado el jugador de esta posición en el equipo todos estrellas correspondiente a la serie especificada");
            return starPosPlayer;
        }

        public List<List<PlayerPosition>> GetStarPositionPlayersSeries()
        {

            var all = _context.StarPositionPlayersSeries.ToList();
            List<List<PlayerPosition>> res = new List<List<PlayerPosition>>();
            foreach (var item in all.Select(c => c.Serie).ToList())
            {
                res.Add(all.Where(c => c.SerieId == item.Id).Select(c=> c.Player).ToList());
            }
            return res;
        }

        public bool RemoveStarPositionPlayer(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var currStarPosPlayer = _context.StarPositionPlayersSeries.SingleOrDefault(c => c.SerieId == starPositionPlayerSerie.SerieId && c.SerieInitDate == starPositionPlayerSerie.SerieInitDate && c.SerieEndDate == starPositionPlayerSerie.SerieEndDate && c.PositionId == starPositionPlayerSerie.PositionId);
            if(currStarPosPlayer == null)
                return false;
            _context.StarPositionPlayersSeries.Remove(currStarPosPlayer);
            _context.SaveChanges();
            return true;

        }

        public StarPositionPlayerSerie UpdateStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var currStarPosPlayer = _context.StarPositionPlayersSeries.SingleOrDefault(c => c.SerieId == starPositionPlayerSerie.SerieId && c.SerieInitDate == starPositionPlayerSerie.SerieInitDate && c.SerieEndDate == starPositionPlayerSerie.SerieEndDate && c.PositionId == starPositionPlayerSerie.PositionId);
            if (currStarPosPlayer == null)
                throw new Exception("No se encuentra un jugador en la posición correspondiente en el equipo todos estrellas de la serie especificada");
            currStarPosPlayer.PlayerId = starPositionPlayerSerie.PlayerId;
            _context.StarPositionPlayersSeries.Update(currStarPosPlayer);
            _context.SaveChanges();
            return currStarPosPlayer;
        }
    }
}
