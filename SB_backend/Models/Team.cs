using System;
using System.ComponentModel.DataAnnotations;

namespace SB_backend.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Initials { get; set; }
        public string img { get; set; }
    }
}