using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class DTOStarTeam
    {
        public Serie Serie { get; set; }
        public List<PlayerPosition> Players { get; set; }
    }
}
