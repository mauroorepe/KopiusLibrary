namespace KopiusLibrary.Model.Entities
{
    public class Publisher : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
