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
        public Guid gameGameId { get; set; }
        [Required]
        public Guid gameWinerTeamId { get; set; }
        [Required]
        public Guid gameLoserTeamId { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime gameGameDate { get; set; }
        [Column(TypeName = "time")]
        [Required]
        public TimeSpan gameGameTime { get; set; }
        [Required]
        public Guid gameSerieId { get; set; }
        [Required]
        public DateTime gameSerieInitDate { get; set; }
        [Required]
        public DateTime gameSerieEndDate { get; set; }
        [ForeignKey("gameGameId,gameWinerTeamId,gameLoserTeamId,gameGameDate,gameGameTime,gameSerieId,gameSerieInitDate,gameSerieEndDate")]
        public Game game {get; set;}
        [Required]
        public Guid PositionId { get; set; }
        public Position Position { get; set; }
        [Required]
        public Guid PlayerId { get; set; }
        //[ForeignKey("PositionPlayerPlayerId,PositionPlayerPositionId")]
        public Player Player { get; set; }
    }
}
