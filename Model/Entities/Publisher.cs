using System.Text.Json.Serialization;

namespace KopiusLibrary.Model.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
