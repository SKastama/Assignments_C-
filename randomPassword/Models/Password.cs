using System.ComponentModel.DataAnnotations;

namespace randomPassword.Models
{
    public class Password
    {
        [Range(0, 32)]
        public int? count { get; set; }
    }
}