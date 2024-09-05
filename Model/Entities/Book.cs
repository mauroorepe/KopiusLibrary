namespace KopiusLibrary.Model.Entities
{
    public class Book : BaseEntity, IEquatable<Book>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public ICollection<AuthorBook> AuthorBook { get; set; }
        public ICollection<BookGenre> BookGenre { get; set; }
        public int YearOfPublication { get; set; }
        public string ISBN { get; set; }
        public Branch Branch { get; set; }
        public string Prologue { get; set; }
        public Publisher? Publisher { get; set; }
        public bool Available { get; set; } = true;

        public bool Equals(Book? other)
        {
            return this.ISBN == other?.ISBN;
        }
    }
}
