using Libraries.Application.Dtos.Book;
using MediatR;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksWithAuthorQuery : IRequest<IEnumerable<BookDto>>
    {
        public int LibraryId { get; set; }
        public int AuthorId { get; set; }

        public GetAllBooksWithAuthorQuery(int authorId, int libraryId = 0)
        {
            LibraryId = libraryId;

            AuthorId = authorId;
        }
    }
}