using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Director
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "El nombre excede la cantidad de caracteres permitidos")]
        public string Name { get; set; }
    }
}
