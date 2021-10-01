using System.ComponentModel.DataAnnotations;

namespace dojoSurveyValidations.Models
{
    public class User
    {
        [MinLength(2)]
        [Display(Name = "Name: ")] 
        public string Name {get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Location: ")] 
        public string Location {get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Language:")] 
        public string Language {get;set;}
        
        [MinLength(2)]
        [MaxLength(20)]
        [Display(Name = "Comments (optional): ")] 
        public string Comments {get;set;}
    }
}