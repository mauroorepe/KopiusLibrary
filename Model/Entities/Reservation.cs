namespace KopiusLibrary.Model.Entities
{
    public class Reservation : BaseEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime Date { get; set; }
    }
}
