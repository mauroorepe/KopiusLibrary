namespace KopiusLibrary.Model.DTOs
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
