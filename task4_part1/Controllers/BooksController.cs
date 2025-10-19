using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task4_part1.Models;

namespace task4_part1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Books>> Get()
        {
            return Ok(_booksRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Books> GetId(int id)
        {
            var book = _booksRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Books> Post(Books book)
        {
            var newBook = _booksRepository.Add(book);
            return Ok(newBook);
        }

        [HttpPut("{id}")]
        public ActionResult<Books> Put(Books book, int id)
        {
            if (book.Id != id)
            {
                return BadRequest();
            }
            _booksRepository.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Books> Delete(int id)
        {
            _booksRepository.Delete(id);
            return NoContent();
        }
    }

}
