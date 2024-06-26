﻿using AutoMapper;
using Libraries.Application.Dtos.Library;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Library.Handlers
{
    public class GetLibraryByIdHandler : IRequestHandler<GetLibraryByIdQuery, LibraryDto>
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
            return _mapper.Map<LibraryDto>(await _libraryRepository.GetById(request.Id));
        }
    }
}