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
    public class GetAllBooksCheckedOutForUserHandler : IRequestHandler<GetAllBooksCheckedOutForUserQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksCheckedOutForUserHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksCheckedOutForUserQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllCheckedOutForUser(request.UserId)).Select(_mapper.Map<BookDto>);
        }
    }
}