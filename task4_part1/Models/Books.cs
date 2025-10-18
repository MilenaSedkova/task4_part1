namespace task4_part1.Models
{
    public class Books
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateOnly PublishedYear { get; set; } 
        public long AuthorId {  get; set; } 
    }
}
