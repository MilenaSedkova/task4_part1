using task4_part1.DTOs;

namespace task4_part1.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        BookDTO? GetById(int id);
        BookDTO? Add(BookDTO bookDTO);

        void Update(BookDTO bookDTO);
        void Delete(int id);
    }
}
