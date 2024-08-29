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
        public IEnumerable<BookDto> GetByTitle(string title)
        {
            var filteredBooks = Context.Books
                .Include(b => b.AuthorBook)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.BookGenre)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.Branch)
                .Include(b => b.Publisher)
                .Where(b => (b.Title).ToLower().Contains(title.ToLower()))
                .ToList();
            return filteredBooks.Select(filteredBooks => _mapper.Map<BookDto>(filteredBooks)).ToList();
        }
        public void Add(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var authorBooks= new List<AuthorBook>();
            
            foreach (var authorDto in bookDto.Authors)
            {
                var existingAuthor = GetAuthorByName(authorDto.Name);
                if (existingAuthor == null)
                {
                    existingAuthor=_mapper.Map<Author>(authorDto);
                }
                authorBooks.Add(new AuthorBook { Author = existingAuthor });
            }
            book.AuthorBook = authorBooks;

            var bookGenres = new List<BookGenre>();
            foreach (var genreDto in bookDto.Genres)
            {
                var existingName= GetGenreByName(genreDto.Name);
                if(existingName == null)
                {
                    existingName=_mapper.Map<Genre>(genreDto);
                }
                bookGenres.Add(new BookGenre { Genre = existingName });
            }
            book.BookGenre = bookGenres;

            var existingBranch = GetBranchByName(bookDto.Branch.Address);
            if (existingBranch != null)
            {
                book.Branch= existingBranch;
            }
            else
            {
                book.Branch= _mapper.Map<Branch>(bookDto.Branch);
            }

            var existingPublisher = GetPublisherByName(bookDto.Publisher.Name);
            if (existingPublisher != null)
            {
                book.Publisher= existingPublisher;
            }
            else
            {
                book.Publisher= _mapper.Map<Publisher>(bookDto.Publisher);
            }

            Context.Books.Add(book);
            Context.SaveChanges();
        }

        public void Delete(BookDto book)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorByName(string name)
        {
            return Context.Authors.FirstOrDefault(a => (a.Name).ToLower() == name.ToLower());
        }

        public Genre GetGenreByName(string name)
        {
            return Context.Genres.FirstOrDefault(g => (g.Name).ToLower() == name.ToLower());
        }

        public Branch GetBranchByName(string address)
        {
            return Context.Branchs.FirstOrDefault(b => (b.Address).ToLower() == address.ToLower());
        }

        public Publisher GetPublisherByName(string name)
        {
            return Context.Publishers.FirstOrDefault(p => (p.Name).ToLower() == name.ToLower());
        }
    }
}
