using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksCheckedOutQuery : IRequest<IEnumerable<BookDto>>
    {
        public int LibraryId { get; set; }

        public GetAllBooksCheckedOutQuery(int libraryId)
        {
            LibraryId = libraryId;
        }
    }
}