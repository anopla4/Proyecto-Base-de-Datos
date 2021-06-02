using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class DTOPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Team Current_Team { get; set; }
        public int Age { get; set; }
        public int Year_Experience { get; set; }
        public int DeffAverage { get; set; }
        public int? ERA { get; set; }
        public int? Average { get; set; }

        public int? Hand { get; set; }
        public string ImgPath { get; set; }

        public List<Position> Positions;
        public List<string> Teams;
    }
}
