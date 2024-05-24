using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksCheckedOutForUserQuery : IRequest<IEnumerable<BookDto>>
    {
        public int UserId { get; set; }

        public GetAllBooksCheckedOutForUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}