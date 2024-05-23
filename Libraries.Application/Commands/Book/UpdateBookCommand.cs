using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class UpdateBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public UpdateBookCommand(UpdateBookDto book)
        {
            Id = book.Id;
            AuthorId = book.AuthorId;
            Title = book.Title;
            Description = book.Description;
        }
    }
}