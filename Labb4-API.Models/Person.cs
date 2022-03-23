using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb4_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }

        public ICollection<Hobby> Hobbies { get; set; }
    }
}
