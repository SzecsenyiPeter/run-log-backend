using RunLog.Dto;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    interface UserService
    {
        public void RegisterUser(UserDto user);
        public User LoginUser(string username, string password);
        public User AuthenticateUser(string username, string passwordHash);
    }
}
