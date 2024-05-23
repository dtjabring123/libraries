using AutoMapper.Configuration.Conventions;
using Libraries.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Book
{
    public class RemoveCheckOutFromBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public RemoveCheckOutFromBookCommand(int id)
        {
            Id = id;
        }
    }
}