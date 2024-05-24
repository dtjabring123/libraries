using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Author.Handlers
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
    {
        public readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorsHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return (await _authorRepository.GetAll()).Select(_mapper.Map<AuthorDto>);
        }
    }
}