using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RunLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RunLog.Service
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string AUTHORIZATION_COOKIE_KEY = "RunLogAuthorization";
        UserService userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserService userService)
            : base(options, logger, encoder, clock) 
        {
            this.userService = userService;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Cookies.ContainsKey("RunLogAuthorization"))
            {
                return AuthenticateResult.Fail("Authentication cookie was not found");
            }
            string[] cookeSplit = Request.Cookies[AUTHORIZATION_COOKIE_KEY].Split(":");
            string username = cookeSplit[0];
            string passwordHash = cookeSplit[1];
            User user = userService.AuthenticateUser(username, passwordHash); 
            if(user != null)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, user.Username) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Password or username invalid");
            }
        }
    }
}
