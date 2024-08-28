namespace KopiusLibrary.Model.DTOs
{
    public class BookDetailsDTO
    {
        public string Title { get; set; }
        public IEnumerable<AuthorDetailsDTO> Authors { get; set; }
        public IEnumerable<GenreDetailsDTO> Genres { get; set; }
        public BranchDetailsDTO Branch { get; set; }
        public PublisherDetailsDTO Publisher { get; set; }
    }
}
