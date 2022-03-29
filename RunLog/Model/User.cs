using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Model
{
    public enum UserTypes
    {
        COACH,
        ATHLETE,
    }
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String PasswordHash { get; set; }
        public UserTypes UserType { get; set; }
    }
}
