using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Proiect_web_final.Models.MyValidation;


namespace lab6.Models
{
    //[Table("Contacts")]
    [Table("Persone")]
    public class Persone
    {
        public int PersoneId { get; set; }

        [Required, RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public string PhoneNumber { get; set; }



        [Required, RegularExpression(@"^[1-9](\d{3})$", ErrorMessage = "This is not a valid year!")]
        public int BirthYear { get; set; }

        [Required, RegularExpression(@"^(0[1-9])|(1[012])$", ErrorMessage = "This is not a valid month!")]
        public string BirthMonth { get; set; }

        [Required, RegularExpression(@"^((0[1-9])|([12]\d)|(3[01]))$", ErrorMessage = "This is not a valid day number!")]
        public string BirthDay { get; set; }

        //[Required]
        public Gender GenderType { get; set; }

        public bool Resident { get; set; }

        
        //one-to-many
        public int RegionId { get; set; }
        //[Required]
        public Region Region { get; set; }

        // one-to-one relationship
        public virtual Rezervation Rezervation { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}