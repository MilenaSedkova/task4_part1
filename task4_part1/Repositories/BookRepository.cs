using System.Xml.Linq;
using task4_part1.Interfaces;
using task4_part1.Models;

namespace task4_part1.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly List<Books> _books = new List<Books>();
        private int _id = 1;

        public IEnumerable<Books> GetAll()
        {
            return _books;
        }

        public Books? GetById(int id)
        {
            return _books.FirstOrDefault(Book => Book.Id == id);
        }
        public Books Add(Books book)
        {
            book.Id = _id++;
            _books.Add(book);
            return book;
        }

        public void Update(Books book)
        {
            var index = _books.FindIndex(Book => Book.Id == book.Id);
            if (index != -1)
            {
                _books[index] = book;
            }
            else
            {
                Console.WriteLine("Книга не найдена(");
            }
        }
        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
            else
            {
                Console.WriteLine("Книга не надена(");
            }
        }
    }
}

