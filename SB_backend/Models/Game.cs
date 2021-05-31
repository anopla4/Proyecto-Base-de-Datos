using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        [Required]
        public Guid WinerTeamId { get; set; }
        public Team WinerTeam { get; set; }
        [Required]
        public Guid LoserTeamId { get; set; }
        public Team LoserTeam { get; set; }
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
        [ForeignKey("SerieId,SerieInitDate,SerieEndDate")]
        public Serie Serie { get; set; }
        public Guid PitcherWinerId { get; set; }
        public Guid PitcherWinerPositionId { get; set; }
        [ForeignKey("PitcherWinerPlayerId,PitcherWinerPositionId")]
        public Player PitcherWiner { get; set; }
        public Guid PitcherLoserId { get; set; }
        public Guid PitcherLoserPositionId { get; set; }
        [ForeignKey("PitcherLoserPlayerId,PitcherLoserPositionId")]
        public Player PitcherLoser { get; set; }
        public int InFavorCarrers { get; set; }
        public int AgaintsCarrers { get; set; }

    }
}
