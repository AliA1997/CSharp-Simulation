using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Houser.Domain;


namespace Houser.Data.Repositories.Impl
{
    public class UserRepo : IUserRepo
    {
        private readonly HouserContext context;
        public UserRepo(HouserContext _context)
        {
            context = _context;
        }

    }
}
