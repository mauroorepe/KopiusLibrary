using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public LibraryContext Context { get; set; }
        public GenreRepository(LibraryContext libraryContext)
        {
            Context = libraryContext;
        }
        public Genre GenreByName(string name)
        {
            return Context.Genres.FirstOrDefault(g => (g.Name).ToLower() == name.ToLower());
        }
    }
}
