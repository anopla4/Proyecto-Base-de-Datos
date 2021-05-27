using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class TeamSerie
    {
        [Key, ForeignKey("Team"), Column(Order = 0)]
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        //[Key, ForeignKey("Serie"), Column(Order = 1)]
        public Guid SerieId { get; set; }
        //[Key, ForeignKey("Serie"), Column(Order = 2, TypeName = "date")]
        public DateTime SerieInitDate { get; set; }
        //        [Key, ForeignKey("Serie"), Column(TypeName = "date", Order = 3)]
        public DateTime SerieEndDate { get; set; }
        [ForeignKey("SerieId,SerieInitDate,SerieEndDate")]
        public Serie Serie { get; set; }
        public int WinnerGames { get; set; }
        public int LosserGames { get; set; }
        public int FinalPosition { get; set; }
    }
}
