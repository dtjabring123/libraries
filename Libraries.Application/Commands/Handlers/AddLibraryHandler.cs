using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Handlers
{
    public class AddLibraryHandler : IRequestHandler<AddLibraryCommand, LibraryDto>
    {
        public readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public AddLibraryHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<LibraryDto> Handle(AddLibraryCommand command, CancellationToken cancellationToken)
        {
            var libraryEntity = new LibraryEntity
            {
                Name = command.Name,
                Description = command.Description
            };
            var result = await _libraryRepository.Add(libraryEntity);
            return _mapper.Map<LibraryDto>(result);
        }
    }
}