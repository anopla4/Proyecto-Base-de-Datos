using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class PositionPlayer
    {   
        [Key,ForeignKey("Player")]
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        [Key,ForeignKey("Position")]
        public Guid PositionId { get; set; }
        public Position Position { get; set; }
        public int Position_Average { get; set; }
    }
}
