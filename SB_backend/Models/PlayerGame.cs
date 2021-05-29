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
        [Required]
        public Guid WinerTeamId { get; set; }
        [Required]
        public Guid LoserTeamId { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime GameDate { get; set; }
        [Column(TypeName = "time")]
        [Required]
        public TimeSpan GameTime { get; set; }
        [Required]
        public Guid SerieId { get; set; }
        [Required]
        public DateTime SerieInitDate { get; set; }
        [Required]
        public DateTime SerieEndDate { get; set; }
        [ForeignKey("GameId,WinerTeamId,LoserTeamId,GameDate,GameTime,SereieId,SerieInitDate,SerieEndDate")]
        public Game Game;
        [Required]
        public Guid PositionPlayerPlayerId { get; set; }
        [Required]
        public Guid PositionPlayerPositionId { get; set; }
        [ForeignKey("PositionPlayerPlayerId,PositionPlayerPositionId")]
        public PositionPlayer PositionPlayer { get; set; }
    }
}
