using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballicaWebApp.Models
{
    public class Footballer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Team { get; set; }
        [Required]
        public string Nationalty { get; set; }
       
    }
}
