using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Author
{
    public class AddAuthorCommand : IRequest<AuthorDto>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AddAuthorCommand(AddAuthorDto author)
        {
            Name = author.Name;
            Description = author.Description;
        }
    }
}