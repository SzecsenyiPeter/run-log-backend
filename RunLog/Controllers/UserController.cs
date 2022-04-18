using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunLog.Dto;
using RunLog.Exceptions;
using RunLog.Model;
using RunLog.Service;
using System.Collections.Generic;
using System.Security.Claims;

namespace RunLog.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;

        }

        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterUser(UserDto createUser)
        {
            try
            {
                userService.RegisterUser(createUser);
                return StatusCode(201);
            }
            catch (UserAlreadyExistsException exception)
            {
                return StatusCode(409, exception.Message);
            }

        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDto> LoginUser(LoginUserDto loginUserDto)
        {
            User user = userService.LoginUser(loginUserDto.Username, loginUserDto.Password);
            if(user != null)
            {
                Response.Cookies.Append(BasicAuthenticationHandler.AUTHORIZATION_COOKIE_KEY, user.Username + ":" + user.PasswordHash);
                return Ok(user);
            }
            else
            {
                return StatusCode(401, "User authentication failed!");
            }
        }
        [Route("athletes")]
        [HttpGet]
        public List<string> GetAthletes(bool showUnaffiliated)
        {
            return userService.GetAthletes(showUnaffiliated? User.FindFirstValue(ClaimTypes.Name) : null);
        }
        [Route("athletes/{athleteName}/coach")]
        [HttpPatch]
        public void SetAthletesCoach(string athleteName)
        {
            userService.SetCoachOfAthlete(User.FindFirstValue(ClaimTypes.Name), athleteName);
        }
    }
}
