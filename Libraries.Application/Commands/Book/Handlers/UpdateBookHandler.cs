using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Entities;
using Libraries.Domain.Interfaces;
using MediatR;

namespace Libraries.Application.Commands.Book.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        public readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BookEntity
            {
                Id = request.Id,
                AuthorId = request.AuthorId,
                LibraryId = request.LibraryId,
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
            };
            return _mapper.Map<BookDto>(await _bookRepository.Update(book));
        }
    }
}