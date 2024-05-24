using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksReservedQuery : IRequest<IEnumerable<BookDto>>
    {
        public int LibraryId { get; set; }

        public GetAllBooksReservedQuery(int libraryId = 0)
        {
            LibraryId = libraryId;
        }
    }
}