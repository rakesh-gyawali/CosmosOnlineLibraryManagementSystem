using AutoMapper;
using OnlineLibraryMVCApi.Dtos;
using OnlineLibraryMVCApi.Models;

namespace OnlineLibraryMVCApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Author, AuthorDto>();
            Mapper.CreateMap<Publication, PublicationDto>();

            Mapper.CreateMap<BookDto, Book>();
            Mapper.CreateMap<CategoryDto, Category>().ForMember(b => b.Id, opt => opt.Ignore());
            Mapper.CreateMap<AuthorDto, Author>().ForMember(b => b.Id, opt => opt.Ignore());
            Mapper.CreateMap<PublicationDto, Publication>().ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}