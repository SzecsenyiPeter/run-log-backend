using Microsoft.AspNetCore.Mvc;
using RunLog.Data;
using RunLog.Dto;
using RunLog.Model;
using System;

namespace RunLog.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly RunLogContext runLogContext;

        public UserController()
        {
            runLogContext = new RunLogContext();
        }
        [Route("register")]
        [HttpPost]
        public bool RegisterUser(CreateUser createUser)
        {

            User newUser = new User
            {
                Username = createUser.Username,
                PasswordHash = HashString(createUser.Password),
                UserType = createUser.UserType,

            };
            runLogContext.Users.Add(newUser);
            runLogContext.SaveChanges();
            return true;
        }
        static string HashString(string text, string salt = "")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }
}
