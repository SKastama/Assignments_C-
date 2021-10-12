using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }


        [Required]
        [Display(Name = "Wedder One ")] 
        [MinLength(2, ErrorMessage="Wedder One must be 2 characters or longer!")]
        public string WedderOne { get; set; }

        [Required]
        [Display(Name = "Wedder Two ")] 
        [MinLength(2, ErrorMessage="Wedder Two must be 2 characters or longer!")]
        public string WedderTwo { get; set; }

        [Required]
        [Display(Name = "Date ")] 
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Wedding Address ")] 
        public string Address { get; set; }

        public int UserId { get; set; }
        public User Creator { get; set; }

        public List<Reservation> Reservations { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}