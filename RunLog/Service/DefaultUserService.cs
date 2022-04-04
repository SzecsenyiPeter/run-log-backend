using RunLog.Data;
using RunLog.Dto;
using RunLog.Exceptions;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public class DefaultUserService : UserService
    {
        
        private readonly RunLogContext runLogContext;
        public DefaultUserService()
        {
            runLogContext = new RunLogContext();

        }
        public void RegisterUser(UserDto createUser)
        {
            User newUser = new User
            {
                Username = createUser.Username,
                PasswordHash = HashString(createUser.Password),
                UserType = createUser.UserType,

            };
            if(runLogContext.Users.Where(user => user.Username == newUser.Username).FirstOrDefault() != null)
            {
                throw new UserAlreadyExistsException();
            }
            runLogContext.Users.Add(newUser);
            runLogContext.SaveChanges();
        }
        public User LoginUser(string username, string password)
        {
            string passwordHash = HashString(password);
            return AuthenticateUser(username, passwordHash);

        }
        public User AuthenticateUser(string username, string passwordHash)
        {
            return runLogContext.Users.Where(user => user.Username == username && user.PasswordHash == passwordHash).FirstOrDefault();
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
