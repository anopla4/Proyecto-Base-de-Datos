using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Pitcher:PositionPlayer
    {
        public double ERA { get; set; }
        public string Hand { get; set; }
    }
}
