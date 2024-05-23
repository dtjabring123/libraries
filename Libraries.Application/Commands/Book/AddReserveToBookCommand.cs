using Libraries.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Book
{
    public class AddReserveToBookCommand : IRequest<BookDto>
    {
        public int BookId { get; set; }
        public int UserId { get; set; }

        public AddReserveToBookCommand(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}