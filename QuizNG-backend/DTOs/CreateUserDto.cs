using System.ComponentModel.DataAnnotations;

namespace QuizNG_backend.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
