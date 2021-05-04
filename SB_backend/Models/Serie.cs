using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SB_backend.Models
{
    public class Serie
    {
        
        public Guid Id { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime Fecha_Final { get; set; }

        public string Nombre { get; set; }

        public Caracter CaracterSerie { get; set; }
    }
}
