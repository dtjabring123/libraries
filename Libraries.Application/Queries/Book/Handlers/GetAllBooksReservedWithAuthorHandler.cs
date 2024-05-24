using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Queries.Book.Handlers
{
    public class GetAllBooksReservedWithAuthorHandler : IRequestHandler<GetAllBooksReservedWithAuthorQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksReservedWithAuthorHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksReservedWithAuthorQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllReservedWithAuthor(request.AuthorId, request.LibraryId)).Select(_mapper.Map<BookDto>);
        }
    }
}