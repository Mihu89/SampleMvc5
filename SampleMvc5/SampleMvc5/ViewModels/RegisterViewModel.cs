using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMvc5.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage ="The password and confirmed password do not match")]
        public string ConfirmedPasword { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}