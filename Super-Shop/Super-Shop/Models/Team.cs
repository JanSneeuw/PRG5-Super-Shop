using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Shop.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int PowerLevel
        {
            get
            {
                //TODO: How to calculate team power?
                return 0;
            }
        }

        public string ImageUri { get; set; }

        [NotMapped]
        public int[] MemberIds { get; set; }

        public List<Hero> Members { get; set; }
    }
}