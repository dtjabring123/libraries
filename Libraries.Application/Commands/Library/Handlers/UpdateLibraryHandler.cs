using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Library.Handlers
{
    public class UpdateLibraryHandler : IRequestHandler<UpdateLibraryCommand, LibraryDto>
    {
        public readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public UpdateLibraryHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<LibraryDto> Handle(UpdateLibraryCommand command, CancellationToken cancellationToken)
        {
            var library = new LibraryEntity
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description
            };
            return _mapper.Map<LibraryDto>(await _libraryRepository.Update(library));
        }
    }
}