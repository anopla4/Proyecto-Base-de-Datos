using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Caracter
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Caracter_Name { get; set; }
    }
}
