using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuizNG_backend.Data;

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
    }
}
