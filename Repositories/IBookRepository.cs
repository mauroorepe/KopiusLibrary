using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<BookDetailsDTO> GetAll();
        IEnumerable<Book> GetByTitle(string title);
        void Add (Book book);
        void Delete (Book book);
    }
}
