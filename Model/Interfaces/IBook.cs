using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Model.Interfaces
{
    public interface IBook
    {
        string Title { get; set; }
        Guid Id { get; set; }
        ICollection<Author> Authors { get; set; }
        Genre? Genre { get; set; }
        int YearOfPublication { get; set; }
        string? ISBN { get; set; }
        string? Prologue { get; set; }
        Publisher? Publisher { get; set; }
        Branch Branch { get; set; }
    }
}
