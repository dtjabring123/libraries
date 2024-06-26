﻿using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

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

        public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BookEntity
            {
                AuthorId = request.AuthorId,
                Title = request.Title,
                Description = request.Description,
            };
            return _mapper.Map<BookDto>(await _bookRepository.Add(book));
        }
    }
}