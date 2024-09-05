namespace KopiusLibrary.Model.Entities
{
    public class Price : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Book Book { get; set; }
        public float BookPrice { get; set; }
    }
}
