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
        }
    }
}