using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Book.Handlers
{
    public class RemoveCheckOutFromBookHandler : IRequestHandler<RemoveCheckOutFromBookCommand, BookDto>
    {
        public readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public RemoveCheckOutFromBookHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(RemoveCheckOutFromBookCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<BookDto>(await _bookRepository.RemoveCheckOut(request.Id));
        }
    }
}