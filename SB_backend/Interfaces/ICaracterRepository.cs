using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ICaracterRepository
    {
        List<Caracter> GetCaracters();
        Caracter GetCaracter(Guid id);

        Caracter AddCaracter(Caracter caracter);

        bool RemoveCaracter(Caracter caracter);

        Caracter UpdateCaracter(Caracter caracter);
    }
}
