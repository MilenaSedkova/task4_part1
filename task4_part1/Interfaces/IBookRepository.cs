using task4_part1.Models;

namespace task4_part1.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Books> GetAll();
        Books? GetById(int id);
        Books Add(Books book);
        void Update(Books id);
        void Delete(int id);
    }
}
