using ECommerce.WebApi.System.Models.Identity;

namespace ECommerce.WebApi.System.Services.Identity
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterInputModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginInputModel model);
        Task<UserManagerResponse> LogoutUserAsync();
        Task<UserManagerResponse> GetUserProfileAsync(string userId);

        // Additional methods like UpdateUser, DeleteUser, etc.

    }
}
