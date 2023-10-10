using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace twoTable.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly DbContextClass _context;

        public BooksController(DbContextClass context)
        {
            _context = context;
        }

        [HttpPost("/book")]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // GET: api/books
        [HttpGet("/book")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/books/1
        [HttpGet("/book/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
