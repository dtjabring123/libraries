using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Library.Handlers
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

        public async Task<LibraryDto> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<LibraryDto>(await _libraryRepository.Delete(request.Id));
        }
    }
}