﻿namespace ECommerce.WebApi.System.Models.Identity
{
    public class ChangePasswordInputModel
    {
        public string UserId { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
