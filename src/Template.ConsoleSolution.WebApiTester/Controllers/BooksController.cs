using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Template.ConsoleSolution.WebApiTester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> Books = new List<Book>();

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Books;
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(Guid id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);

            if (book is null) return NotFound();

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book value)
        {
            Books.Add(value);
            return value;
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Book value)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);

            if (book is null) return NotFound();

            Books.Remove(book);
            Books.Add(value);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(Guid id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);

            if (book is null) return NotFound();

            Books.Remove(book);
            return book;
        }
    }
}