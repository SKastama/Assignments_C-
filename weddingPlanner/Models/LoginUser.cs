using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "LoginEmail ")] 
        public string LoginEmail {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "LoginPassword ")] 
        public string LoginPassword { get; set; }
    }
}