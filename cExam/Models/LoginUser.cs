using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cExam.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Email ")] 
        public string LoginEmail {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")] 
        public string LoginPassword { get; set; }
    }
}