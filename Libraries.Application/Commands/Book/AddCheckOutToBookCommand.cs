using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class AddCheckOutToBookCommand : IRequest<BookDto>
    {
        public int BookId { get; set; }
        public int UserId { get; set; }

        public AddCheckOutToBookCommand(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}