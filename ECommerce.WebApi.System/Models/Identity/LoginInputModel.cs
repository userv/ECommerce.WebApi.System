namespace ECommerce.WebApi.System.Models.Identity
{
    public class LoginInputModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
