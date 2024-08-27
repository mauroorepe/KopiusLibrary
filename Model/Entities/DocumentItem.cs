namespace KopiusLibrary.Model.Entities
{
    public class DocumentItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid PriceId { get; set; }
        public Guid BookId { get; set; }
        public Guid DocumentId { get; set; }
        public float Subtotal { get; set; }
    }
}
