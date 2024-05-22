using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Author.Handlers
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, AuthorDto>
    {
        public readonly IAuthorRepository _authorRepository;
        public readonly IMapper _mapper;

        public DeleteAuthorHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.Delete(request.Id));
        }
    }
}