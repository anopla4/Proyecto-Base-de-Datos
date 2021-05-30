using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class PitcherChangeGame
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
        public Guid PitcherInPlayerId { get; set; }
        public Guid PitcherInPositionId { get; set; }
        [ForeignKey("PitcherInPlayerId,PitcherInPositionId")]

        public Pitcher PitcherIn { get; set; }
        public Guid PitcherOutPlayerId { get; set; }
        public Guid PitcherOutPositionId { get; set; }
        [ForeignKey("PitcherOutPlayerId,PitcherOutPositionId")]
        public Pitcher PitcherOut { get; set; }
    }
}
