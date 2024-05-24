using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Book.Handlers
{
    public class GetAllBooksReservedForUserHandler : IRequestHandler<GetAllBooksReservedForUserQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksReservedForUserHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksReservedForUserQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllReservedForUser(request.UserId)).Select(_mapper.Map<BookDto>);
        }
    }
}