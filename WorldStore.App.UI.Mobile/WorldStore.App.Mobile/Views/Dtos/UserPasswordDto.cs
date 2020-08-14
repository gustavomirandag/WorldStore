using System;
using System.Collections.Generic;
using System.Text;

namespace WorldStoreApp.Views.Dtos
{
    public class UserPasswordDto
    {
        public User user { get; set; }
        public Password password { get; set; }
    }

    public class User
    {
        public string userName { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public bool lockoutEnabled { get; set; }
    }

    public class Password
    {
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
