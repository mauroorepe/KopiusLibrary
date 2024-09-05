using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace KopiusLibrary.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBook()
        {
            return _bookRepository.GetAll();

        }

        [HttpGet("{title}")]
        public IActionResult GetBookByTitle(string title)
        {
            IEnumerable<BookDto> Books = _bookRepository.GetByTitle(title);
            if (Books == null)
            {
                return NotFound();
            }

            return Ok(Books);
        }

        [HttpPost]

        public ActionResult AddBook([FromBody]BookDto newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            //if (_bookRepository.ValidateISBN(newBook.ISBN, newBook.Title))//quantity, tabla intermedia entre sucursal y libro
            //{
            //    return BadRequest();
            //}

            //if (string.IsNullOrEmpty(newBook.Title) || newBook.AuthorBook == null || !newBook.AuthorBook.Any() || newBook.BookGenre==null || !newBook.BookGenre.Any())
            //{
            //    return BadRequest("Invalid book data. Title and Authors are required.");
            //}

            _bookRepository.Add(newBook);

            return Ok();
        }

        [HttpPatch("{isbn}")]
        public ActionResult DeleteBook(string isbn)
        {
            var book = _bookRepository.BookByIsbn(isbn);
            if (book != null)
            {
                book.Available = false;
                _bookRepository.Update(book);
                return NoContent();
            }
            return BadRequest();

        }
    }
}
