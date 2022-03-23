using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string URL { get; set; }
        [Required]
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }

    }
}
