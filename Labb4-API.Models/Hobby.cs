using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_API.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
