using AutoMapper;
using ECommerce.WebApi.System.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.WebApi.System.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IJwtTokenGeneratorService jwtTokenGeneratorService;
        private readonly IConfiguration configuration;


        public UserService(UserManager<User> userManager,
            IConfiguration configuration,
            IJwtTokenGeneratorService jwtTokenGeneratorService,
            SignInManager<User> signInManager
            )
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.jwtTokenGeneratorService = jwtTokenGeneratorService;
            this.signInManager = signInManager;

        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterInputModel model)
        {
            if (model == null)
                throw new NullReferenceException("Register Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Password = model.Password,
                Role = model.Role,


            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Optionally, add claims or roles here

                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginInputModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that email address",
                    IsSuccess = false,
                };
            }

            var result = await userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            // Generate JWT Token
            //var token = GenerateJwtToken(user);
            var token = jwtTokenGeneratorService.GenerateJwtToken(user, configuration);

            return new UserManagerResponse
            {
                Message = "Logged in successfully",
                IsSuccess = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)

            };
        }

        public async Task<UserManagerResponse> LogoutUserAsync()
        {
            await signInManager.SignOutAsync();
            return new UserManagerResponse
            {
                Message = "Logged out successfully",
                IsSuccess = true
            };
        }

        //private string GenerateJwtToken(User user)
        //{

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"]);

        //    Console.WriteLine(configuration["JwtSettings:Secret"]);
        //    Console.WriteLine(key);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //            new Claim(ClaimTypes.Name, user.Email)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var encryptedToken = tokenHandler.WriteToken(token);

        //    return encryptedToken;
        //}

        public async Task<UserManagerResponse> GetUserProfileAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
