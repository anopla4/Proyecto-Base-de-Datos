using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Game
    {
        public Guid WinerTeamId { get; set; }
        public Team WinerTeam { get; set; }
        public Guid LoserTeamId { get; set; }
        public Team LoserTeam { get; set; }
        [Column(TypeName = "date")]
        public DateTime GameDate { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan GameTime { get; set; }
        public Guid SerieId { get; set; }
        public DateTime SerieInitDate { get; set; }
        public DateTime SerieEndDate { get; set; }
        [ForeignKey("SerieId,SerieInitDate,SerieEndDate")]
        public Serie Serie { get; set; }
        public Guid PitcherWinerPlayerId { get; set; }
        public Guid PitcherWinerPositionId { get; set; }
        [ForeignKey("PitcherWinerPlayerId,PitcherWinerPositionId")]
        public Pitcher PitcherWiner { get; set; }
        public Guid PitcherLoserPlayerId { get; set; }
        public Guid PitcherLoserPositionId { get; set; }
        [ForeignKey("PitcherLoserPlayerId,PitcherLoserPositionId")]
        public Pitcher PitcherLoser { get; set; }
        public int InFavorCarrers { get; set; }
        public int AgaintsCarrers { get; set; }

    }
}
