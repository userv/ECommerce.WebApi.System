using ECommerce.WebApi.System.Models;


namespace ECommerce.WebApi.System.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterInputModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginInputModel model);
        Task<UserManagerResponse> GetUserProfileAsync(string userId);

        // Additional methods like UpdateUser, DeleteUser, etc.

    }
}
