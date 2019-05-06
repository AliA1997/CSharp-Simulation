using Houser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Houser.Services.Services.Impl
{
    public class UserService
    {
        private readonly IUserRepo _repo;
        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        
    }
}
