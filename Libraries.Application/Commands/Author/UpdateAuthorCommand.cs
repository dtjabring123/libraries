using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<AuthorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public UpdateAuthorCommand(UpdateAuthorDto author)
        {
            Id = author.Id;
            Name = author.Name;
            Description = author.Description;
        }
    }
}