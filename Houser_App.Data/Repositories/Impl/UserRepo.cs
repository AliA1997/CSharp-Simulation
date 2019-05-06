using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Houser.Domain;
using Houser_App.Data.Repositories;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Houser.Data.Repositories.Impl
{
    public class UserRepo : IUserRepo
    {
        private readonly HouserContext context;
        public UserRepo(HouserContext _context)
        {
            context = _context;
        }

        public async Task Login(User user)
        {
            User u = await context.Users.FirstOrDefaultAsync(returnUser =>
                                                            returnUser.UserName == user.UserName
                                                            );
            if (u == null)
                return;

            bool credentials = u.Password.Equals(user.Password);

            //If the credentials passes return a 200 status code, and generate a token.

            TokenManager.GenerateToken(user.UserName);

            return;
        }

    }
}
