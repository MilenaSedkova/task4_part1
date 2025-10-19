using System.ComponentModel.DataAnnotations;

namespace task4_part1.Models
{
    public class Books
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Название книги обязательно")]
        public string? Title { get; set; }
        public DateOnly PublishedYear { get; set; }

        [Required(ErrorMessage = "Необходимо указать автора")]
        public long AuthorId {  get; set; } 
    }
}
