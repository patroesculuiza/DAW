﻿//using Proiect_web_final.Models.MyValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace lab6.Models
{
    public class RezervationContactViewModel
    {
        [Required,MinLength(2, ErrorMessage = "Rezervation name cannot be less than 2!"),
       MaxLength(30, ErrorMessage = "Rezervation name cannot be more than 30!")]
        public string Name { get; set; }

        [Required,RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public string PhoneNumber { get; set; }

        [Required, RegularExpression(@"^[1-9](\d{3})$", ErrorMessage = "This is not a valid year!")]
        public int BirthYear { get; set; }

        [Required, RegularExpression(@"^(0[1-9])|(1[012])$", ErrorMessage = "This is not a valid month!")]
        public string BirthMonth { get; set; }

        [Required, RegularExpression(@"^((0[1-9])|([12]\d)|(3[01]))$", ErrorMessage = "This is not a valid day number!")]
        public string BirthDay { get; set; }

        [Required]
        public Gender GenderType { get; set; }
        //[Required]
        public bool Resident { get; set; }

        [Required]
        public int RegionId { get; set; }
    }
}