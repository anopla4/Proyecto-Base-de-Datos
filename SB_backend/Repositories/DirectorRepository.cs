using SB_backend.Interfaces;
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

        public Director getDirector(Guid id)
        {
            return _context.Directors.SingleOrDefault(c => c.Id == id);
        }

        public List<Director> getDirectors()
        {
            return _context.Directors.ToList();
        }

        public bool RemoveDirector(Director director)
        {
            var current_director = _context.Directors.Find(director.Id);
            if(current_director != null)
            {
                _context.Directors.Remove(current_director);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Director UpdateDirector(Director director)
        {
            var current_director = _context.Directors.Find(director.Id);
            if(current_director != null)
            {
                current_director.Name = director.Name;
                _context.Directors.Update(current_director);
                _context.SaveChanges();
                return current_director;
            }
            return current_director;
        }
    }
}
