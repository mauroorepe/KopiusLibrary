namespace KopiusLibrary.Model.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}