using KopiusLibrary.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Model.Entities
{
    public class Book :IEquatable<Book>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public ICollection<AuthorBook> AuthorBook { get; set; }
        public ICollection<BookGenre> BookGenre { get; set; }
        public int YearOfPublication { get; set; }
        public string? ISBN { get; set; }
        public Branch Branch { get; set; }
        public string? Prologue { get; set; }
        public Publisher? Publisher { get; set; }

        public bool Equals(Book? other)
        {
            return this.ISBN == other?.ISBN;
        }
    }
}
