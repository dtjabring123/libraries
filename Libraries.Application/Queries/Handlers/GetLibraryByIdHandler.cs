using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Queries.Handlers
{
    public class GetLibraryByIdHandler : IRequestHandler<GetLibraryByIdQuery,LibraryDto>
    {
        public readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibraryByIdHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<LibraryDto> Handle(GetLibraryByIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var libraryEntity = await _libraryRepository.GetById(id);
            return _mapper.Map<LibraryDto>(libraryEntity);
        }
    }
}
