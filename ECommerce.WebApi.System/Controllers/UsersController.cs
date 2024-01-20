﻿using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models;
using ECommerce.WebApi.System.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Controllers
{
    public class UsersController : ApiController
    {
        private readonly ECommerceDbContext db;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        private readonly SignInManager<User> signInManager;
        //private readonly IConfiguration configuration; 
        //private readonly IEmailSender emailSender;

        public UsersController(
            ECommerceDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserService userService
        )
        {
            this.userService = userService;
            this.db = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.configuration = configuration;
            //this.emailSender = emailSender;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register([FromBody] RegisterInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var result = await this.userService.RegisterUserAsync(input);
            if (result.IsSuccess)
            {
                await this.userService.LoginUserAsync(new LoginInputModel() { Email = input.Email, Password = input.Password });
                return this.Ok(result.Token);
            }
            else
            {
                return this.BadRequest(result.Errors);
            }
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult> Login([FromBody] LoginInputModel input)
        {
            // var user = await this.userManager.FindByEmailAsync(input.Email);
            var result = await this.userService.LoginUserAsync(input);
            if (!result.IsSuccess)
            {
                return this.BadRequest(result.Errors);
            }

            return this.Ok(result.Token);

        }

        [HttpPost]
        [Route(nameof(Logout))]
        public async Task<ActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.Ok();
        }

        [HttpPost]
        [Route(nameof(ForgotPassword))]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordInputModel input)
        {
            var user = await this.userManager.FindByEmailAsync(input.Email);
            if (user == null)
            {
                return this.BadRequest();
            }

            //var token = await this.userManager.GeneratePasswordResetTokenAsync(user);
            //var callbackUrl = this.Url.Page(
            //                   "/Account/ResetPassword",
            //                                  pageHandler: null,
            //                                  values: new { token, email = user.Email },
            //                                  protocol: this.Request.Scheme);
            return this.Ok();
        }


    }
}