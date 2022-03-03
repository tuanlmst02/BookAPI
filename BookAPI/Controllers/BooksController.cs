using BookAPI.Models;
using BookAPI.Responsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookResponsitory _bookResponsitory;

        public BooksController(IBookResponsitory bookResponsitory)
        {
            _bookResponsitory = bookResponsitory;
        }


        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookResponsitory.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return await _bookResponsitory.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookResponsitory.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookResponsitory.Update(book);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            await _bookResponsitory.Delete(id);
            return NoContent();
        }

    }
}
