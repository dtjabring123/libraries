using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class AddBookCommand : IRequest<BookDto>
    {
        public AddBookCommand(AddBookDto book)
        {
            AuthorId = book.AuthorId;
            LibraryId = book.LibraryId;
            UserId = book.UserId;
            Title = book.Title;
            Description = book.Description;
        }

        public int AuthorId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? LibraryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? UserId { get; set; }
    }
}