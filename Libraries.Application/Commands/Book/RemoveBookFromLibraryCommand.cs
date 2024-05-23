using Libraries.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Book
{
    public class RemoveBookFromLibraryCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public RemoveBookFromLibraryCommand(int id)
        {
            Id = id;
        }
    }
}