using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class CambiosJugadoresPosicion
    {
        public Juego Juego_ { get; set; }

        public JugadorPosicion Entra { get; set; }
        public JugadorPosicion Sale { get; set; }

    }
}
