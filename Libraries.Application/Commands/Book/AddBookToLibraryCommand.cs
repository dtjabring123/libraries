using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class AddBookToLibraryCommand : IRequest<BookDto>
    {
        public int BookId { get; set; }
        public int LibraryId { get; set; }

        public AddBookToLibraryCommand(int bookId, int libraryId)
        {
            BookId = bookId;
            LibraryId = libraryId;
        }
    }
}