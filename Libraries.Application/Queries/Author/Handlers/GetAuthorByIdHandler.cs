using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Author.Handlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        public readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.GetById(request.Id));
        }
    }
}