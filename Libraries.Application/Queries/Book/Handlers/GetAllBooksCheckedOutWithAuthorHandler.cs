using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Queries.Book.Handlers
{
    public class GetAllBooksCheckedOutWithAuthorHandler : IRequestHandler<GetAllBooksCheckedOutWithAuthorQuery, IEnumerable<BookDto>>
    {
        public IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksCheckedOutWithAuthorHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksCheckedOutWithAuthorQuery request, CancellationToken cancellationToken)
        {
            return (await _bookRepository.GetAllCheckedOutWithAuthor(request.AuthorId, request.LibraryId)).Select(_mapper.Map<BookDto>);
        }
    }
}