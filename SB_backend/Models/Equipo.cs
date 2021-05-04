using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Equipo
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Color { get; set; }

        public string Iniciales { get; set; }
    }
}
