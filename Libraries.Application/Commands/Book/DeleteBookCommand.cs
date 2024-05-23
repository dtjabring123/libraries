using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class DeleteBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}