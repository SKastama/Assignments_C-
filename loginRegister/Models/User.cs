using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginRegister.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [Required]
        [Display(Name = "First Name ")] 
        [MinLength(2, ErrorMessage="First Name must be 2 characters or longer!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name ")] 
        [MinLength(2, ErrorMessage="Last Name must be 2 characters or longer!")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ")] 
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")] 
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        [NotMapped]
        [Compare("Password", ErrorMessage="Both Passwords must match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password ")] 
        public string Confirm {get;set;}
    }
}