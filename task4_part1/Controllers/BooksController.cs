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


    }
}
