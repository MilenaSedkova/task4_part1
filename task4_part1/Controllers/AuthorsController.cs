using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task4_part1.Models;
using task4_part1.Interfaces;
namespace task4_part1.Controllers;
using task4_part1.DTOs;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<AuthorDTO>> Get()
    {
        return Ok(_authorService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<AuthorDTO> GetId(int id)
    {
        var author = _authorService.GetById(id);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [HttpPost]
    public ActionResult<AuthorDTO> Post([FromBody] AuthorDTO authorDTO)
    {
        var newAuthor = _authorService.Add(authorDTO);
        return Ok(newAuthor);
    }

    [HttpPut("{id}")]
    public ActionResult Put(AuthorDTO authorDTO, int id)
    {
        if (authorDTO.Id != id)
        {
            return BadRequest();
        }
        _authorService.Update(authorDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _authorService.Delete(id);
        return NoContent();
    }
}
