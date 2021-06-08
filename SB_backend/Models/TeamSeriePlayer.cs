using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class TeamSeriePlayer
    {
        public Guid PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
        public Guid SerieId { get; set; }
        public DateTime SerieInitDate { get; set; }
        public DateTime SerieEndDate { get; set; }
        [ForeignKey("SerieId,SerieInitDate,SerieEndDate")]
        public Serie Serie { get; set; }
        public Guid TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team{ get; set; }
    }
}
