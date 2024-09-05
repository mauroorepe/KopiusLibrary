namespace KopiusLibrary.Model.Entities
{
    public class Client : BaseEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
