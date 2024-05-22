using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Library.Handlers
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

        public async Task<LibraryDto> Handle(AddLibraryCommand request, CancellationToken cancellationToken)
        {
            var library = new LibraryEntity
            {
                Name = request.Name,
                Description = request.Description
            };
            return _mapper.Map<LibraryDto>(await _libraryRepository.Add(library));
        }
    }
}