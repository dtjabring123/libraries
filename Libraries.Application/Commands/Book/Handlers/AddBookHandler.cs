using AutoMapper;
using Libraries.Application.Dtos;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Book.Handlers
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, BookDto>
    {
        public readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var book = new BookEntity
            {
                AuthorId = command.AuthorId,
                LibraryId = command.LibraryId,
                UserId = command.UserId,
                Title = command.Title,
                Description = command.Description,
            };
            return _mapper.Map<BookDto>(await _bookRepository.Add(book));
        }
    }
}