using System.Data;
using task4_part1.DTOs;
using task4_part1.Interfaces;
using task4_part1.Models;

namespace task4_part1.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        private BookDTO MapToDTO(Books books)
        {
            return new BookDTO
            {
                Id = books.Id,
                Title = books.Title,
                PublishedYear = books.PublishedYear,
                AuthorId = books.AuthorId,
            };
        }
        public IEnumerable<BookDTO> GetAll()
        {
            return _bookRepository.GetAll().Select(x => MapToDTO(x));
        }
        public BookDTO GetById(int id)
        {
            var book=_bookRepository.GetById(id);
            return book == null ? null : MapToDTO(book);
        }
        public BookDTO Add(BookDTO bookDTO)
        {
            var bookEntity = new Books()
            {
                Title = bookDTO.Title,
                PublishedYear = bookDTO.PublishedYear,
                AuthorId = bookDTO.AuthorId,
            };
            var newBook=_bookRepository.Add(bookEntity);
            return MapToDTO(newBook);

        }
        public void Update(BookDTO bookDTO)
        {
            var bookEntity = new Books()
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                PublishedYear = bookDTO.PublishedYear,
                AuthorId = bookDTO.AuthorId,
            };
            _bookRepository.Update(bookEntity);
        }
        public void Delete(int id)
        {
            if (_bookRepository.GetById != null)
            {
                _bookRepository.Delete(id);
            }
        }
    }
}
