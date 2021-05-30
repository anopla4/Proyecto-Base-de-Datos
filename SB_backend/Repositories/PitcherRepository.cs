using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class PitcherRepository : IPitcherRepository
    {
        private AppDBContext _context;
        public PitcherRepository(AppDBContext context)
        {
            _context = context;
        }

        public Pitcher AddPitcher(Pitcher pitcher)
        {
            pitcher.PositionId = _context.Positions.SingleOrDefault(c => c.PositionName == "P").Id;
            _context.Pitchers.Add(pitcher);
            _context.SaveChanges();
            return pitcher;
        }

        public Pitcher GetPitcher(Guid Id)
        {
            var pitcher = _context.Pitchers.Include(c => c.Position).SingleOrDefault(c => c.PlayerId == Id);
            if (pitcher == null)
                return null;
            return pitcher;
        }

        public List<Pitcher> GetPitchers()
        {
            return _context.Pitchers.ToList();
        }

        public bool RemovePitcher(Pitcher pitcher)
        {
            var curr_pitcher = _context.Pitchers.Find(pitcher.PlayerId);
            if (curr_pitcher == null)
                return false;
            _context.Pitchers.Remove(curr_pitcher);
            _context.SaveChanges();
            return true;
        }

        public Pitcher UpdatePitcher(Pitcher pitcher)
        {
            var curr_pitcher = _context.Pitchers.Find(pitcher.PlayerId);
            if (curr_pitcher == null)
                return null;
            curr_pitcher.ERA = pitcher.ERA;
            curr_pitcher.Hand = pitcher.Hand;
            return curr_pitcher;
        }
    }
}
