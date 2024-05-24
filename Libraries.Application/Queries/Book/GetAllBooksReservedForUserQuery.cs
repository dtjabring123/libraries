using Libraries.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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