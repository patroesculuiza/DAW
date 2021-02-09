using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Utility
    {
        public int UtilityId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Genre name cannot be less than 3!"),
        MaxLength(20, ErrorMessage = "Genre name cannot be more than 20!")]
        public string Name { get; set; }

        // many-to-many relationship
        public virtual ICollection<Room> rooms { get; set; }

    }
}