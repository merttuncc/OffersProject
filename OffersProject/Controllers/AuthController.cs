using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffersProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OffersProject.Models.UserModels;
using OfferModels.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace OffersProject.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthRepository _authRepository;
        IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegister userForRegister)
        {

            if (await _authRepository.UserExists(userForRegister.FirstName))
            {
                ModelState.AddModelError("UserName", "Username already exists");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User
            {
                Id=userForRegister.Id,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                RegistrationNumber = userForRegister.RegistrationNumber,
                Mail = userForRegister.Mail,
                PhoneNumber = userForRegister.PhoneNumber,
                Password=userForRegister.Password,
                Role=userForRegister.Role


            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegister.Password);
            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserForLogin userForLogin)
        {
            var user = await _authRepository.Login(userForLogin.FirstName, userForLogin.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.FirstName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

    }
}
