using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Lanzador : JugadorPosicion
    {
        public decimal ERA { get; set; } //promedio de carreras limpias

        public string Mano { get; set; } //mano con la que lanza

        public Lanzador()
        {
            this.PosicionJugador = new Posicion("Lanzador");
        }
    }
}
