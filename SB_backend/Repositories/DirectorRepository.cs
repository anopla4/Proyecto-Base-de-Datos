﻿using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private AppDBContext _context;

        public DirectorRepository(AppDBContext context)
        {
            _context = context;        
        }
        public Director AddDirector(Director director)
        {
            director.Id = Guid.NewGuid();
            _context.Directors.Add(director);
            _context.SaveChanges();
            return director;
        }

        public Director GetDirector(Guid id)
        {
            var director = _context.Directors.SingleOrDefault(c => c.Id == id);
            if (director == null)
                throw new KeyNotFoundException("No se encuentra el director especificado");
            return director;
        }

        public List<Director> GetDirectors()
        {
            return _context.Directors.ToList();
        }

        public bool RemoveDirector(Guid Id)
        {
            var current_director = _context.Directors.Find(Id);
            if(current_director != null)
            {
                foreach (var tsd in _context.TeamsSeriesDirectors.Where(x => x.DirectorId == Id))
                    _context.TeamsSeriesDirectors.Remove(tsd);
                _context.Directors.Remove(current_director);
                _context.SaveChanges();
                return true;
            }
            throw new KeyNotFoundException("No se encuentra el direcctor especificado");
        }

        public Director UpdateDirector(Director director)
        {
            var current_director = _context.Directors.Find(director.Id);
            if(current_director != null)
            {
                current_director.Name = director.Name;
                if(director.ImgPath != null)
                    current_director.ImgPath = director.ImgPath;
                _context.Directors.Update(current_director);
                _context.SaveChanges();
                return current_director;
            }
            throw new KeyNotFoundException("No se encuentra el director especificado");
        }
    }
}
