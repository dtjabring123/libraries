using Libraries.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Queries.Book
{
    public class GetAllBooksCheckedOutWithAuthorQuery : IRequest<IEnumerable<BookDto>>
    {
        public int LibraryId { get; set; }
        public int AuthorId { get; set; }

        public GetAllBooksCheckedOutWithAuthorQuery(int authorId, int libraryId = 0)
        {
            LibraryId = libraryId;
            AuthorId = authorId;
        }
    }
}