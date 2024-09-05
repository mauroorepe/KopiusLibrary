using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Repositories
{
    public interface IPublisherRepository
    {
        Publisher PublisherByName(string name);
    }
}
