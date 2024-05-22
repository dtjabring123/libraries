using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Commands.Library
{
    public class UpdateLibraryCommand : IRequest<LibraryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public UpdateLibraryCommand(LibraryDto library)
        {
            Id = library.Id;
            Name = library.Name;
            Description = library.Description;
        }
    }
}