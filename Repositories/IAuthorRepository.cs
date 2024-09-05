using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IAuthorRepository
    {
        Author AuthorByName(string name);
    }
}
