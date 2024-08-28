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

        public BookRepository(LibraryContext context)
        {
            Context = context;
        }

        public IEnumerable<BookDetailsDTO> GetAll()
        {
            return Context.Books
               .Include(b => b.AuthorBook)
                .ThenInclude(ab => ab.Author)
               .Include(b => b.BookGenre)
                .ThenInclude(bg => bg.Genre)
               .Include(b => b.Branch)
               .Include(b => b.Publisher)
               .Select(b => new BookDetailsDTO
                {
                    Title = b.Title,
                    Authors = b.AuthorBook.Select(ab => new AuthorDetailsDTO
                    {
                        Name = ab.Author.Name,
                        Bio = ab.Author.Bio,
                        BirthDay = ab.Author.BirthDay,
                        DeathDate = ab.Author.DeathDate
                    }),
                    //Genres = b.BookGenre.Select(bg => new GenreDetails
                    //{
                    //    Name = bg.Genre.Name
                    //}),
                    //Branch = b.Branch == null ? null : new BranchDetails
                    //{
                    //    Address = b.Branch.Adress,
                    //    PhoneNumber = b.Branch.PhoneNumber.ToString(),
                    //    Email = b.Branch.Email
                    //},
                    //Publisher = b.Publisher == null ? null : new PublisherDetails
                    //{
                    //    Name = b.Publisher.Name
                    //}
                })
                .ToList();
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
