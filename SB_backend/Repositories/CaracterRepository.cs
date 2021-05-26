using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class CaracterRepository : ICaracterRepository
    {
        private AppDBContext _context;
        public CaracterRepository(AppDBContext context)
        {
            _context = context;
        }
        public Caracter AddCaracter(Caracter caracter)
        {
            caracter.Id = Guid.NewGuid();
            _context.Caracters.Add(caracter);
            return caracter;
        }

        public Caracter getCaracter(Guid id)
        {
            Caracter caracter = _context.Caracters.SingleOrDefault(c => c.Id == id);
            return caracter;
        }

        public List<Caracter> getCaracters()
        {
            return _context.Caracters.ToList();
        }

        public bool RemoveCaracter(Caracter caracter)
        {
            var curr_car = _context.Caracters.Find(caracter.Id);

            if (curr_car != null)
            {
                _context.Remove(curr_car);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Caracter UpdateCaracter(Caracter caracter)
        {
            var curr_car = _context.Caracters.Find(caracter.Id);

            if (curr_car != null)
            {
                curr_car.Caracter_Name = caracter.Caracter_Name;
                _context.Caracters.Update(curr_car);
                _context.SaveChanges();
            }
            return curr_car;
        }
    }
}
