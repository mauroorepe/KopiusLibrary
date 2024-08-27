using System.Text.Json.Serialization;

namespace KopiusLibrary.Model.Entities
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
    }
}
