namespace KopiusLibrary.Model.Entities
{
    public class AuthorBook
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
