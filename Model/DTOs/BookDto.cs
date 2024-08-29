using System.ComponentModel.DataAnnotations;

namespace KopiusLibrary.Model.DTOs
{
    public class BookDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Year of Publication is required")]
        public int YearOfPublication { get; set; }
        [Required(ErrorMessage = "Author/s are required")]
        public IEnumerable<AuthorDto> Authors { get; set; }
        [Required(ErrorMessage = "Genre/s are required")]
        public IEnumerable<GenreDto> Genres { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public BranchDto Branch { get; set; }
        [Required(ErrorMessage = "Publisher is required")]
        public PublisherDto Publisher { get; set; }
        [Required(ErrorMessage = "Prologue is required")]
        public string Prologue { get; set; }
    }
}
