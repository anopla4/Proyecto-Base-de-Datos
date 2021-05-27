﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class Serie
    {
        public Serie()
        {
            this.NumberOfGames = 0;
        }
        public Guid Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime InitDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CaracterId { get; set; }
        public Caracter CaracterSerie { get; set; }
        public int NumberOfGames { get; set; }
    }
}
