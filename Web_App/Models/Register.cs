﻿namespace Web_App.Models
{
    public class RegisterUser
    {
        public required string Username { get; set; }
        public required string Mobile { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; } 

    }
}
