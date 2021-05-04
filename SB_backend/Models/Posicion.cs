using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Posicion
    {
        public string Name { get; set; }

        public Posicion(string Name)
        {
            this.Name = Name;
        }
    }
}
