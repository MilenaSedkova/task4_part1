using task4_part1.DTOs;

namespace task4_part1.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> GetAll();
        AuthorDTO? GetById(int id);
        AuthorDTO? Add (AuthorDTO authorDTO);
        void Update(AuthorDTO authorDTO);
        void Delete(int id);
    }
}
