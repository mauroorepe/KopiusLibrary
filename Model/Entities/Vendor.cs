namespace KopiusLibrary.Model.Entities
{
    public class Vendor : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Joined { get; set; }
        public DateTime OutDate { get; set; }
        public Role Role { get; set; }
        public Branch Branch { get; set; }
    }
}
