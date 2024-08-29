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

            CreateMap<BookDto, Book>()
            .ForMember(dest => dest.AuthorBook, opt => opt.Ignore())
            //    src.Authors.Select(authorDto => new AuthorBook
            //    {
            //        Author = new Author
            //        {
            //            Bio = authorDto.Bio,
            //            Name = authorDto.Name,
            //            BirthDay = authorDto.BirthDay,
            //            DeathDate = authorDto.DeathDate
            //        }
            //    })
            //))
            .ForMember(dest => dest.BookGenre, opt => opt.Ignore());
            //    src.Genres.Select(genreDto => new BookGenre
            //    {
            //        Genre = new Genre
            //        {
            //            Name = genreDto.Name
            //        }
            //    })
            //));
            CreateMap<AuthorDto, Author>();
            CreateMap<BranchDto, Branch>();
            CreateMap<GenreDto, Genre>();
            CreateMap<PublisherDto, Publisher>();
        }
    }
}
