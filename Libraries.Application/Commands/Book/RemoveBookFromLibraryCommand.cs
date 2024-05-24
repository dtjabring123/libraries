using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class RemoveBookFromLibraryCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public RemoveBookFromLibraryCommand(int id)
        {
            Id = id;
        }
    }
}