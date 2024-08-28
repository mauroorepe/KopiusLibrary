using AutoMapper;
using KopiusLibrary.Model;
using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        public LibraryContext Context { get; set; }
        private readonly IMapper _mapper;
        public BookRepository(LibraryContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public ActionResult<IEnumerable<BookDto>> GetAll()
        {
            var books = Context.Books
            .Include(b => b.AuthorBook)
                .ThenInclude(ab => ab.Author)
            .Include(b => b.BookGenre)
                .ThenInclude(bg => bg.Genre)
            .Include(b => b.Branch)
            .Include(b => b.Publisher)
               .ToList();
            return books.Select(book => _mapper.Map<BookDto>(book)).ToList();
        }
        public IEnumerable<Book> GetByTitle(string title)
        {
            return Context.Books
                .Include(b => b.AuthorBook)
                .Include(b => b.BookGenre)
                .Include(b => b.Branch)
                .Include(b => b.Publisher)
                .Where(b => (b.Title).ToLower().Contains(title.ToLower()))
                .ToList();
        }
        public void Add(Book book)
        {
            Context.Books.Add(book);
            try
            {
                Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
                //return StatusCodes(500, $"Internal server error: {ex.Message}");
            }
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
