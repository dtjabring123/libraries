using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Commands.Book
{
    public class RemoveCheckOutFromBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public RemoveCheckOutFromBookCommand(int id)
        {
            Id = id;
        }
    }
}