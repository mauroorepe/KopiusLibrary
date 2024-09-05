namespace KopiusLibrary.Model.Entities
{
    public class Supplier : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

    }
}
