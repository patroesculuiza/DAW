using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Furniture
    {
        [Key]
        public int FurnitureId { get; set; }

        [Required, MinLength(2, ErrorMessage = "Furniture type name cannot be less than 2!"),
        MaxLength(20, ErrorMessage = "Furniture type name cannot be more than 20!")]
        public string TypeFurniture { get; set; }

        //many to one
        public virtual ICollection<Room> Rooms { get; set; }

    }
}