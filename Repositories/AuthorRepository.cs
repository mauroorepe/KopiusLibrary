using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public LibraryContext Context { get; set; }
        public AuthorRepository(LibraryContext libraryContext)
        {
            Context = libraryContext;
        }
        public Author AuthorByName(string name)
        {
            return Context.Authors.FirstOrDefault(a => (a.Name).ToLower() == name.ToLower());
        }
    }
}
