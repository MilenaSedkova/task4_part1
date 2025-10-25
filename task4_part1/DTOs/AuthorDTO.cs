using System.ComponentModel.DataAnnotations;

namespace task4_part1.DTOs
{
    public class AuthorDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Укажите имя автора")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Укажите фамилию автора")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения автора")]
        public DateTime DateOfBirth { get; set; }
    }
}
