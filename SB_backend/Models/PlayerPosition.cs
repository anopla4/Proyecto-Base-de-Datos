using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class PlayerPosition
    {
        [ForeignKey("Player"), Column(Order = 0)]
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey("Position"), Column(Order = 1)]
        public Guid PositionId { get; set; }
        public Position Position { get; set; }

    }
}
