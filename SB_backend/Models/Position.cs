using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Position
    {
        [Key]
        public Guid Id { get; set; }
        [Key]
        public string Position_Name { get; set; }
    }
}
