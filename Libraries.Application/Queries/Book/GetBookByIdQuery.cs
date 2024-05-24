using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}