using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace QuizNG_backend.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
