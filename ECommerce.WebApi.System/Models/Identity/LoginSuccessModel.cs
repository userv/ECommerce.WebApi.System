﻿namespace ECommerce.WebApi.System.Models.Identity
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }

        public string UserId { get; }

        public string Token { get; }
    }
}
