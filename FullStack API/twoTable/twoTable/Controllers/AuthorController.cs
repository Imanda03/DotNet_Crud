using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twoTable.Models;

namespace twoTable.Controllers
{
    public class AuthorController : ControllerBase
    {
        private readonly DbContextClass _context;

        public AuthorController(DbContextClass context)
        {
            _context = context;
        }

        [HttpPost("/author")]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // GET: api/authors
        [HttpGet("/Author")]
        public async Task<ActionResult<IEnumerable<AuthorBookVM>>> GetAuthors()
        {
            //return await _context.Authors.Include(a => a.Books).ToListAsync();

            var result = await (from a in _context.Authors
                                join b in _context.Books on a.AuthorId equals b.AuthorId
                                select new AuthorBookVM
                                {
                                    AuthorId = a.AuthorId,
                                    AuthorName=a.Name,
                                    BookId=b.BookId,
                                    Title =b.Title
                                }).ToListAsync();
            return result;

        }

        // GET: api/authors/1
        [HttpGet("/author/{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }
    }
    }
