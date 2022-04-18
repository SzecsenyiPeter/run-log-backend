using RunLog.Dto;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public interface UserService
    {
        public void RegisterUser(UserDto user);
        public User LoginUser(string username, string password);
        public User AuthenticateUser(string username, string passwordHash);
        public List<string> GetAthletes(string coachName = null);
        public void SetCoachOfAthlete(string coachName, string username);
    }
}
