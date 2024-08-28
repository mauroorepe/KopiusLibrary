namespace KopiusLibrary.Model.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Discount Discount { get; set; }
        public Tax Tax { get; set; }
        public DocumentType DocumentType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Vendor Vendor { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public Branch Branch { get; set; }
        public float TotalAmount { get; set; }
        public Status Status { get; set; }
    }
}
