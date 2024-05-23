using AutoMapper;
using Libraries.Application.Dtos.Library;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Library.Handlers
{
    public class GetAllLibrariesHandler : IRequestHandler<GetAllLibrariesQuery, IEnumerable<LibraryDto>>
    {
        public readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetAllLibrariesHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibraryDto>> Handle(GetAllLibrariesQuery request, CancellationToken cancellationToken)
        {
            var librariesEntity = await _libraryRepository.GetAll();
            return librariesEntity.Select(_mapper.Map<LibraryDto>);
        }
    }
}