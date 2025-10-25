using task4_part1.Models;
using task4_part1.DTOs;
using task4_part1.Interfaces;

namespace task4_part1.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        private AuthorDTO MapToDTO(Author author)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
            };
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            return _authorRepository.GetAll().Select(x => MapToDTO(x));
        }
        public AuthorDTO? GetById(int id)
        {
            var author=_authorRepository.GetById(id);
            return author==null ? null : MapToDTO(author);
        }
        public AuthorDTO Add(AuthorDTO authorDto)
        {
            var authorEntity = new Author()
            {
                Name = authorDto.Name,
                LastName = authorDto.LastName,
                DateOfBirth = authorDto.DateOfBirth,
            };
            var newAuthor=_authorRepository.Add(authorEntity);
            return MapToDTO(newAuthor);         
        }
        public void Update(AuthorDTO authorDto)
        {
            var authorEntity = new Author()
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                LastName = authorDto.LastName,
                DateOfBirth = authorDto.DateOfBirth,
            };
            _authorRepository.Update(authorEntity);
        }
        public void Delete(int id)
        {
            if (_authorRepository.GetById(id) != null)
            {
                _authorRepository.Delete(id);
            }
        }
    }
}
