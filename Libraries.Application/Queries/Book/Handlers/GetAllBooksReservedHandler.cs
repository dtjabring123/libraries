﻿using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Book.Handlers
{
    public class GetAllBooksReservedHandler : IRequestHandler<GetAllBooksReservedQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksReservedHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksReservedQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllReserved(request.LibraryId)).Select(_mapper.Map<BookDto>);
        }
    }
}