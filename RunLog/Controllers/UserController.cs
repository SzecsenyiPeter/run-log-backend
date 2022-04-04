using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunLog.Data;
using RunLog.Dto;
using RunLog.Exceptions;
using RunLog.Model;
using RunLog.Service;
using System;

namespace RunLog.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        [Route("register")]
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
    }
}
