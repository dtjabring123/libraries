using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.Library
{
    public class AddLibraryCommand : IRequest<LibraryDto>
    {
        public AddLibraryCommand(AddLibraryDto library)
        {
            Name = library.Name;
            Description = library.Description;
        }

        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}