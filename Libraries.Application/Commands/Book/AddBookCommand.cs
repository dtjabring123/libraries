using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class AddBookCommand : IRequest<BookDto>
    {
        public int AuthorId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AddBookCommand(AddBookDto book)
        {
            AuthorId = book.AuthorId;
            Title = book.Title;
            Description = book.Description;
        }
    }
}