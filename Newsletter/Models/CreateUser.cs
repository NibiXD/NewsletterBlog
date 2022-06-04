using System.ComponentModel.DataAnnotations;

namespace Newsletter.Models
{
    public class CreateUser
    {
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Minimum characters required {1}")]
        public string Password { get; set; }
    }
}
