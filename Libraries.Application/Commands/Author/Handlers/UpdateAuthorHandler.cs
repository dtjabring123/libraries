using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Author.Handlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, AuthorDto>
    {
        public readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new AuthorEntity
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            return _mapper.Map<AuthorDto>(await _authorRepository.Update(author));
        }
    }
}