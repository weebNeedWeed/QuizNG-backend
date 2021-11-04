using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizNG_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public QuizzesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("random")]
        public async Task<string> GetRandomQuizzes()
        {
            HttpClient client = new HttpClient();

            int limit = (new Random()).Next(10, 21);
            string url = _configuration["ApiUrl"] + "?apiKey=" + _configuration["ApiToken"] + "&limit=" + limit.ToString();

            var jsonString = await client.GetStringAsync(url);

            return jsonString;
        }
    }
}
