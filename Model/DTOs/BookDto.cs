namespace KopiusLibrary.Model.DTOs
{
    public class BookDto
    {
        public string Title { get; set; }
        public IEnumerable<AuthorDto> Authors { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        public BranchDto Branch { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
