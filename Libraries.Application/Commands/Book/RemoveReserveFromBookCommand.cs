using Libraries.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Book
{
    public class RemoveReserveFromBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public RemoveReserveFromBookCommand(int id)
        {
            Id = id;
        }
    }
}