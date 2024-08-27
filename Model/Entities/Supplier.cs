using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KopiusLibrary.Model.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

    }
}
