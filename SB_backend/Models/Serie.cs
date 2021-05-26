using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Serie
    {
        [Key]
        public Guid Id { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime Init_Date { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime End_Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CaracterId { get; set; }
        public Caracter Caracter_Serie { get; set; }
    }
}
