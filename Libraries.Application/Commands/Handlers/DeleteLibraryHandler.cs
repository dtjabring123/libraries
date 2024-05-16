using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Application.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Handlers
{
    public class DeleteLibraryHandler : IRequestHandler<DeleteLibraryCommand, LibraryDto>
    {
        public readonly ILibraryRepository _libraryRepository;
        public readonly IMapper _mapper;

        public DeleteLibraryHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<LibraryDto> Handle(DeleteLibraryCommand command, CancellationToken cancellationToken)
        {
            var id = command.Id;
            var result = await _libraryRepository.Delete(id);
            return _mapper.Map<LibraryDto>(result);
        }
    }
}
