using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Super_Shop.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Hero Hero { get; set; }
        [NotMapped]
        public string HeroName { get; set; }
        public string Email { get; set; }
    }
}