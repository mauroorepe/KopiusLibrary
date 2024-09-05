namespace KopiusLibrary.Model.Entities
{
    public abstract class BaseEntity
    {
        public DateTime? Updated { get; set; }
        public string? UpdatedBy { get; set; }

        //Heredarla en todos
    }
}
