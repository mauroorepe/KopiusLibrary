using AutoMapper;
using KopiusLibrary.Model.Entities;

namespace KopiusLibrary.Model.DTOs
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.AuthorBook.Select(ab => ab.Author)))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenre.Select(bg => bg.Genre)));
            CreateMap<Author, AuthorDto>();
            CreateMap<Branch, BranchDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Publisher, PublisherDto>();
        }
    }
}
