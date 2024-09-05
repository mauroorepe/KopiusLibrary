using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        ActionResult<IEnumerable<BookDto>> GetAll();
        IEnumerable<BookDto> GetByTitle(string title);
        void Add(BookDto book);
        Book BookByIsbn(string isbn);
        void Update(Book book);
        //Author AuthorByName(string name);
        //Genre GenreByName(string name);
        //Branch BranchByName(string Address);
        //Publisher PublisherByName(string name);
        //bool ValidateISBN(string ISBN, string title);
    }
}
