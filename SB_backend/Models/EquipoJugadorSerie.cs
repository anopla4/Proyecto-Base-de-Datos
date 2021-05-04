using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class EquipoJugadorSerie
    {
        public Pelotero Jugador { get; set; }
        public Serie Serie_ { get; set; }
        public Equipo Equipo_ { get; set; }
    }
}
