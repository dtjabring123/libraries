using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;

namespace Libraries.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryEntity, LibraryDto>().ReverseMap();
            CreateMap<AuthorEntity, AuthorDto>().ReverseMap();
            CreateMap<BookEntity, BookDto>().ReverseMap();
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<LibraryEntity, AddLibraryDto>().ReverseMap();
            CreateMap<AuthorEntity, AddAuthorDto>().ReverseMap();
            CreateMap<BookEntity, AddBookDto>().ReverseMap();
            CreateMap<UserEntity, AddUserDto>().ReverseMap();
        }
    }
}