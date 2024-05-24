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
    public class GetAllBooksWithAuthorHandler : IRequestHandler<GetAllBooksWithAuthorQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksWithAuthorHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksWithAuthorQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllWithAuthor(request.AuthorId, request.LibraryId)).Select(_mapper.Map<BookDto>);
        }
    }
}