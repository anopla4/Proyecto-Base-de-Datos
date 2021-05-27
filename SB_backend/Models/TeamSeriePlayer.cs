using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class TeamSeriePlayer
    {
        [ForeignKey("Player")]
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        //[Key, ForeignKey("Serie"), Column(Order = 1)]
        public Guid SerieId { get; set; }
        //[Key, ForeignKey("Serie"), Column(Order = 2, TypeName = "date")]
        public DateTime SerieInitDate { get; set; }
        //        [Key, ForeignKey("Serie"), Column(TypeName = "date", Order = 3)]
        public DateTime SerieEndDate { get; set; }
        [ForeignKey("SerieId,SerieInitDate,SerieEndDate")]
        public Serie Serie { get; set; }
        [ForeignKey("TeamSerie")]
        public Guid TeamSerieId { get; set; }
        public Team TeamSerie { get; set; }
    }
}
