using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task4_part1.Models;
using task4_part1.Interfaces;
using task4_part1.DTOs;

namespace task4_part1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;
        public BooksController(IBookService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get()
        {
            return Ok(_booksService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetId(int id)
        {
            var book = _booksService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Books> Post(BookDTO bookDTO)
        {
            var newBook = _booksService.Add(bookDTO);
            return Ok(newBook);
        }

        [HttpPut("{id}")]
        public ActionResult<BookDTO> Put(BookDTO bookDTO, int id)
        {
            if (bookDTO.Id != id)
            {
                return BadRequest();
            }
            _booksService.Update(bookDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<BookDTO> Delete(int id)
        {
            _booksService.Delete(id);
            return NoContent();
        }
    }

}
