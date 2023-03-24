using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookService.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            _bookService.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}