using ECommerce.WebApi.System.Models;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.WebApi.System.Services
{
    public interface IJwtTokenGeneratorService
    {
        SecurityToken GenerateJwtToken(User user, IConfiguration configuration);


    }
}
