using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class PlayerChangeGame
    {
        [Required]
        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public Guid PlayerIdIn { get; set; }
        public Guid PositionIdIn { get; set; }
        [Required]
        [ForeignKey("PlayerIdIn,PositionIdIn")]
        public PlayerPosition PlayerPositionIn { get; set; }

        public Guid PlayerIdOut { get; set; }
        public Guid PositionIdOut { get; set; }
        [Required]
        [ForeignKey("PlayerIdOut,PositionIdOut")]
        public PlayerPosition PlayerPositionOut { get; set; }
    }
}
