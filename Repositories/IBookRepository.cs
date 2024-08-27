using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetByTitle(string title);
        void Add (Book book);
        void Delete (Book book);
    }
}
