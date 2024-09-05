using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public LibraryContext Context { get; set; }
        public PublisherRepository(LibraryContext libraryContext)
        {
            Context = libraryContext;
        }
        public Publisher PublisherByName(string name)
        {
            //return Context.Publishers.FirstOrDefault(p => (p.Name).ToLower() == name.ToLower());
            return Context.Publishers.FirstOrDefault(p=> p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
