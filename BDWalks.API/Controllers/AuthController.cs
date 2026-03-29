using BDWalks.API.Models.DTOs;
using BDWalks.API.Repositories.Interfaces;
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
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
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
                    // getting the roles
                    var roles = await userManager.GetRolesAsync(user);

                    if(roles != null && roles.Any())
                    {
                        // generate JWT token and return to the client
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        // converting token to a response DTO
                        var response = new LoginResponseDto
                        {
                            jwtToken = jwtToken,
                        };

                        //returning the response
                        return Ok(response);
                    }
                    return BadRequest("User has no role!");
                }
                return BadRequest("Invalid Password!");
            }
            return BadRequest("Invalid Username or Email!");
        }
    }
}
