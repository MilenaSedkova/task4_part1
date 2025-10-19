using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task4_part1.Models;

namespace task4_part1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return Ok(_authorRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetId(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> Post(Author author)
        {
            var newAuthor = _authorRepository.Add(author);
            return Ok(newAuthor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Author author, int id)
        {
            if (author.Id != id)
            {
                return BadRequest();
            }
            _authorRepository.Update(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _authorRepository.Delete(id);
            return NoContent();
        }
    }
}
