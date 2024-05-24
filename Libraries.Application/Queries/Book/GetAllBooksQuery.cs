using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
    {
        public int LibraryId { get; set; }

        public GetAllBooksQuery(int libraryId = 0)
        {
            LibraryId = libraryId;
        }
    }
}