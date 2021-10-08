using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        [Display(Name = "First Name ")] 
        [MinLength(2, ErrorMessage="First Name must be 2 characters or longer!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name ")] 
        [MinLength(2, ErrorMessage="Last Name must be 2 characters or longer!")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birthdate ")] 
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> CreatedDishes {get;set;}
    }

    public class Dish 
    {
        [Key]
        public int DishId { get; set; }


        [Required]
        [Display(Name = "Name of Dish ")] 
        public string DishName { get; set; }

        [Required]
        [Display(Name = "# of Calories ")] 
        [Range(1, 10000)]
        public int Calories { get; set; }

        [Required]
        [Display(Name = "Description ")] 
        public string Description { get; set; }

        [Required]
        [Display(Name = "Tastiness: ")] 
        [Range(1, 5)]
        public int Taste { get; set; }

        public int ChefId { get; set; }
        public Chef Creator { get; set; }
    }
}