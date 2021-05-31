using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class StarPositionPlayerSerie
    {
        [Required]
        public Guid PlayerId { get; set; }
        [Required]
        public Guid PlayerPositionId { get; set; }
        [ForeignKey("PlayerId,PlayerPositionId")]
        public Player Player { get; set; }
        [Required]
        public Guid SerieId { get; set; }
        [Required]
        public DateTime SerieInitDate { get; set; }
        [Required]
        public DateTime SerieEndDate { get; set; }
        [ForeignKey("SerieId,SerieInitDate,SerieEndDate")]
        public Serie Serie{get;set;}
    }
}
