using AutoMapper;
using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;
using KopiusLibrary.Model.Interfaces;
using KopiusLibrary.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            //if (string.IsNullOrEmpty(newBook.Title) || newBook.AuthorBook == null || !newBook.AuthorBook.Any() || newBook.BookGenre==null || !newBook.BookGenre.Any())
            //{
            //    return BadRequest("Invalid book data. Title and Authors are required.");
            //}

            _bookRepository.Add(newBook);

            return Ok();
        }
    }
}
