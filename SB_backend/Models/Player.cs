using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Este nombre excede el número de caracteres permitidos")]
        public string Name { get; set; }

        public Team Current_Team { get; set; }
        public Guid Current_TeamId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Year_Experience { get; set; }
    }
}
