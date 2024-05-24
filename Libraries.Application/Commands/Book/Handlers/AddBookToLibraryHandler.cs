using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Book.Handlers
{
    public class AddBookToLibraryHandler : IRequestHandler<AddBookToLibraryCommand, BookDto>
    {
        public readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookToLibraryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(AddBookToLibraryCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<BookDto>(await _bookRepository.AddToLibrary(request.BookId, request.LibraryId));
        }
    }
}