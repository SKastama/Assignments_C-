using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginRegister.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Email ")] 
        public string Email {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")] 
        public string Password { get; set; }
    }
}