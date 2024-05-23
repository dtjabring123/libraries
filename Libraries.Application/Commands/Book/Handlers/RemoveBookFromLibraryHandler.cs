using AutoMapper;
using Libraries.Application.Dtos.Book;
using Libraries.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Book.Handlers
{
    public class RemoveBookFromLibraryHandler : IRequestHandler<RemoveBookFromLibraryCommand, BookDto>
    {
        public readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public RemoveBookFromLibraryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(RemoveBookFromLibraryCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<BookDto>(await _bookRepository.RemoveFromLibrary(request.Id));
        }
    }
}