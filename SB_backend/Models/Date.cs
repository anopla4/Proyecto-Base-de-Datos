using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Date
    {
        [Key]
        public string Day { get; set; }
        [Key]
        public string Hour { get; set; }
    }
}
