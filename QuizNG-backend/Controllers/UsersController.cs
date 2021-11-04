using Microsoft.AspNetCore.Mvc;
using QuizNG_backend.Data;
using QuizNG_backend.DTOs;
using QuizNG_backend.Models;
using System;
using System.Threading.Tasks;

namespace QuizNG_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly QuizContext _context;

        public UsersController(QuizContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> Register([FromBody]CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newUser = new AppUser()
            {
                UserName = createUserDto.UserName,
                Password = createUserDto.Password
            };

            try
            {
                await _context.AppUsers.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return newUser;
        }
    }
}
