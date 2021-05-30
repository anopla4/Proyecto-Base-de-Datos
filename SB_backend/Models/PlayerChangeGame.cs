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
        public Guid GameGameId { get; set; }
        [Required]
        public Guid GameWinerTeamId { get; set; }
        [Required]
        public Guid GameLoserTeamId { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime GameGameDate { get; set; }
        [Column(TypeName = "time")]
        [Required]
        public TimeSpan GameGameTime { get; set; }
        [Required]
        public Guid GameSerieId { get; set; }
        [Required]
        public DateTime GameSerieInitDate { get; set; }
        [Required]
        public DateTime GameSerieEndDate { get; set; }
        [ForeignKey("GameGameId,GameWinerTeamId,GameLoserTeamId,GameGameDate,GameGameTime,GameSerieId,GameSerieInitDate,GameSerieEndDate")]
        public Game Game { get; set; }
        [Required]
        public Guid PlayerInPlayerId { get; set; }
        [Required]
        public Guid PlayerInPositionId { get; set; }
        [ForeignKey("PlayerInPlayerId,PlayerInPositionId")]
        public PositionPlayer PlayerIn { get; set; }
        [Required]
        public Guid PlayerOutPlayerId { get; set; }
        [Required]
        public Guid PlayerOutPositionId { get; set; }
        [ForeignKey("PlayerOutPlayerId,PlayerOutPositionId")]
        public PositionPlayer PlayerOut { get; set; }
    }
}
