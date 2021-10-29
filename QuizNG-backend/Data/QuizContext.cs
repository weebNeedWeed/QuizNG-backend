using Microsoft.EntityFrameworkCore;
using QuizNG_backend.Models;

namespace QuizNG_backend.Data
{
    public class QuizContext: DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
