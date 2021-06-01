using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class PlayerGame
    {
        [Required]
        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game {get; set;}
        [Required]
        public Guid PlayerId { get; set; }
        [Required]
        public Guid PositionId { get; set; }
        [ForeignKey("PlayerId,PositionId")]
        public PlayerPosition Player { get; set; }
    }
}
