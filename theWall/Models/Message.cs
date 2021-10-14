using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theWall.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        
        [Required]
        [Display(Name = "Message ")] 
        public string messageText {get; set;}

        public int UserId { get; set; }
        public User Creator { get; set; }
        
        public List<Comment> CreatedComments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}