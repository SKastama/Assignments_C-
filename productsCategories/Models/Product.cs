using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Name ")] 
        [MinLength(2, ErrorMessage="Name must be 2 characters or longer!")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Description ")] 
        [MinLength(2, ErrorMessage="Description must be 2 characters or longer!")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price ")] 
        public int Price { get; set; }

        public List<Association> Associations { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}