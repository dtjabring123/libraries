using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksReservedForUserQuery : IRequest<IEnumerable<BookDto>>
    {
        public int UserId { get; set; }

        public GetAllBooksReservedForUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}