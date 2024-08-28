using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        ActionResult<IEnumerable<BookDto>> GetAll();
        IEnumerable<Book> GetByTitle(string title);
        void Add (Book book);
        void Delete (Book book);
    }
}
