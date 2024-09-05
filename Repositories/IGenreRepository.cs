using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IGenreRepository
    {
        Genre GenreByName(string name);
    }
}
