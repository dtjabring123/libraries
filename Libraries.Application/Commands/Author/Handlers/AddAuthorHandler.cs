using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Author.Handlers
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand, AuthorDto>
    {
        public readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AddAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new AuthorEntity
            {
                Name = request.Name,
                Description = request.Description,
            };
            return _mapper.Map<AuthorDto>(await _authorRepository.Add(author));
        }
    }
}