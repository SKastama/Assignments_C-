using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class User
    {
        [Key]

        public int UserId { get; set; }

        [Required]
        [Display(Name = "Chef's Name: ")] 
        public string chefName { get; set; }

        [Required]
        [Display(Name = "Name of Dish: ")] 
        public string dishName { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "# of Calories: ")] 
        public int Calories { get; set; }

        [Required]
        [Display(Name = "Tastiness: ")] 
        public int Taste { get; set; }

        [Required]
        [Display(Name = "Description: ")] 
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}