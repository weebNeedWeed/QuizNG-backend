using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizNG_backend.Data;
using QuizNG_backend.DTOs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizNG_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly QuizContext _context;
        private readonly IConfiguration _configuration;

        public TokensController(QuizContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserLoginDto userLoginDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.UserName == userLoginDto.UserName
            && x.Password == userLoginDto.Password);

            if (user == null)
            {
                return NotFound();
            }

            var expireTime = DateTime.UtcNow.AddDays(1);
            if (!userLoginDto.Remember)
            {
                expireTime = DateTime.UtcNow.AddMinutes(10);
            }

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("UserName", user.UserName),
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                                             expires: expireTime, signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
