using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class AddReserveToBookCommand : IRequest<BookDto>
    {
        public int BookId { get; set; }
        public int UserId { get; set; }

        public AddReserveToBookCommand(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}