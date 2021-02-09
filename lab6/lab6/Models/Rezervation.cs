using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab6.Models
{
    public class Rezervation
    {
        public int RezervationId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Rezervation name cannot be less than 2!"),
        MaxLength(30, ErrorMessage = "Rezervation name cannot be more than 30!")]
        public string Name { get; set; }

        // many-to-one relationship
        public virtual ICollection<Room> Rooms { get; set; }

        // one-to one-relationship
        [Required]
        public virtual Persone Persone { get; set; }



    }
}