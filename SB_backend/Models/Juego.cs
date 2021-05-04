using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Juego
    {
        public Equipo EquipoGanador { get; set; }
        public Equipo EquipoPerdedor { get; set; }
        public Fecha FechaJuego { get; set; }
        public Lanzador LanzadorGanador { get; set; }

        public int CarrerasFavor { get; set; }
        public int CarrerasContra { get; set; }

    }
}
