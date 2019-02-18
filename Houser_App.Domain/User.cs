using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Houser.Domain
{
    public class User: IdentityUser
    {
        private User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Password { get; set; }
        
    }
}
