using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Shop.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PowerLevel { get; set; }

        public string ImageUri { get; set; }

        public ICollection<Team> Teams { get; } = new List<Team>();
    }
}