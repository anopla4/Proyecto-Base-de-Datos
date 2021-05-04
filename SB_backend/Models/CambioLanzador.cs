using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class CambioLanzador
    {
        public Juego Juego_ { get; set; }

        public Lanzador Entra { get; set; }
        public Lanzador Sale { get; set; }

    }
}
