using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theWall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        
        [Required]
        [Display(Name = "Comment ")] 
        public string commentText {get; set;}

        public int UserId { get; set; }
        public User UserCreator { get; set; }

        public int MessageId { get; set; }
        public Message MessageCreator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}