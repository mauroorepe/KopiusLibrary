using AutoMapper;
using KopiusLibrary.Model;
using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;
using KopiusLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        public LibraryContext Context { get; set; }
        private readonly IMapper _mapper;
        private readonly IBaseRepository _baseRepository;
        private readonly ILoginService _loginService; 
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IBranchRepository _branchRepository;
        public BookRepository(LibraryContext context, IMapper mapper, 
            IBaseRepository baseRepository, ILoginService loginService, 
            IAuthorRepository authorRepository, IGenreRepository genreRepository, 
            IPublisherRepository publisherRepository, IBranchRepository branchRepository)
        {
            Context = context;
            _mapper = mapper;
            _baseRepository = baseRepository;
            _loginService = loginService;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;
            _branchRepository = branchRepository;
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

            return books
                .Where(book => book.Available)
                .Select(book => _mapper.Map<BookDto>(book))
                .ToList();
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

            return filteredBooks
                .Where(book => book.Available)
                .Select(filteredBooks => _mapper.Map<BookDto>(filteredBooks))
                .ToList();
        }
        public void Add(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var authorBooks= new List<AuthorBook>();
            
            foreach (var authorDto in bookDto.Authors)
            {
                var existingAuthor = _authorRepository.AuthorByName(authorDto.Name);
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
                var existingName= _genreRepository.GenreByName(genreDto.Name);
                if(existingName == null)
                {
                    existingName=_mapper.Map<Genre>(genreDto);
                }
                bookGenres.Add(new BookGenre { Genre = existingName });
            }
            book.BookGenre = bookGenres;

            var existingBranch = _branchRepository.BranchByName(bookDto.Branch.Address);
            if (existingBranch != null)
            {
                book.Branch= existingBranch;
            }
            else
            {
                book.Branch= _mapper.Map<Branch>(bookDto.Branch);
            }

            var existingPublisher = _publisherRepository.PublisherByName(bookDto.Publisher.Name);
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

        public Book BookByIsbn(string isbn)
        {
            var book = Context.Books.FirstOrDefault(b=> b.ISBN == isbn);
            return book;
        }
        public void Update(Book book)
        {
            _baseRepository.UpdateService(book, "userMauro");
            Context.Books.Update(book);
            Context.SaveChanges();
        }
        //public Author AuthorByName(string name)
        //{
        //    return Context.Authors.FirstOrDefault(a => (a.Name).ToLower() == name.ToLower());
        //}// summary

        //public Genre GenreByName(string name)
        //{
        //    return Context.Genres.FirstOrDefault(g => (g.Name).ToLower() == name.ToLower());
        //}

        //public Branch BranchByName(string address)
        //{
        //    return Context.Branchs.FirstOrDefault(b => (b.Address).ToLower() == address.ToLower());
        //}

        //public Publisher PublisherByName(string name)
        //{
        //    return Context.Publishers.FirstOrDefault(p => (p.Name).ToLower() == name.ToLower());
        //}

        //public Book ValidateISBN(string ISBN)//controller
        //{
        //    foreach (var book in Context.Books)
        //    {
        //        if(book.ISBN == ISBN && book.Title != title)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
