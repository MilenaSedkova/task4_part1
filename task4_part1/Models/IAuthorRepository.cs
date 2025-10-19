namespace task4_part1.Models
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author? GetById(int id);
        Author Add(Author author);
        void Update(Author author);
        void Delete(int id);

    }
}
