using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebApi.System.Models
{
    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
