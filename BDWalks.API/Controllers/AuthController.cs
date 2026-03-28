using BDWalks.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        // POST: api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            // creating a identity user
            var identityUser = new IdentityUser
            {
                UserName = registerUserDto.Username,
                Email = registerUserDto.Username
            };

            // creating the user in the database
            var identityResult = await userManager.CreateAsync(identityUser, registerUserDto.Password);

            if (identityResult.Succeeded)
            {
                // assigning the role to the user
                if(registerUserDto.Roles != null && registerUserDto.Roles.Any())
                {
                    identityResult =  await userManager.AddToRolesAsync(identityUser, registerUserDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User Registered Successfully! Login to continue.");
                    }
                }
            }

            return BadRequest("User Registration Failed!");
        }

        // POST: api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            // check if the user exists in the database
            var user = await userManager.FindByEmailAsync(loginUserDto.Username);

            if(user != null)
            {
                //check if the password is correct
                var isValidPassword = await userManager.CheckPasswordAsync(user, loginUserDto.Password);

                if (isValidPassword)
                {
                    // generate JWT token and return to the client

                    return Ok("Login Successful!");
                }else
                {
                    return BadRequest("Invalid Password!");
                }
            }
            else
            {
                return BadRequest("Invalid Username or Email!");
            }
        }
    }
}
