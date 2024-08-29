using KopiusLibrary.Model.DTOs;
using KopiusLibrary.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Repositories
{
    public interface IBookRepository
    {
        ActionResult<IEnumerable<BookDto>> GetAll();
        IEnumerable<BookDto> GetByTitle(string title);
        void Add (BookDto book);
        void Delete (BookDto book);
        Author GetAuthorByName(string name);
        Genre GetGenreByName(string name);
        Branch GetBranchByName(string Address);
        Publisher GetPublisherByName(string name);
    }
}
