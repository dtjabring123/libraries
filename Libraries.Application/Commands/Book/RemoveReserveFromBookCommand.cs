using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class RemoveReserveFromBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public RemoveReserveFromBookCommand(int id)
        {
            Id = id;
        }
    }
}