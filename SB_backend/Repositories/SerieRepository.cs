using Microsoft.EntityFrameworkCore;
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

        public Serie getSerie(Guid id)
        {
            return _context.Series.Include(c => c.Caracter_Serie).SingleOrDefault(c => c.Id == id);
        }

        public List<Serie> getSeries()
        {
            return _context.Series.Include(c => c.Caracter_Serie).ToList();
        }

        public bool RemoveSerie(Serie serie)
        {
            var curr_serie = _context.Series.Find(serie.Id);

            if (curr_serie != null)
            {
                _context.Series.Remove(curr_serie);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Serie UpdateSerie(Serie serie)
        {
            var curr_serie = _context.Series.Find(serie.Id);

            if (curr_serie != null)
            {
                curr_serie.Name = serie.Name;
                curr_serie.CaracterId = serie.CaracterId;
                curr_serie.Caracter_Serie = curr_serie.Caracter_Serie;
                _context.Series.Update(curr_serie);
                _context.SaveChanges();
            }
            return curr_serie;
        }
    }
}
