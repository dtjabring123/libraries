using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Book.Handlers
{
    public class GetAllBooksCheckedOutHandler : IRequestHandler<GetAllBooksCheckedOutQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksCheckedOutHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksCheckedOutQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllCheckedOut(request.LibraryId)).Select(_mapper.Map<BookDto>);
        }
    }
}