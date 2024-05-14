using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands
{
    public class AddLibraryCommand : IRequest<LibraryDto>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AddLibraryCommand(LibraryDto libraryDto)
        {
            Name = libraryDto.Name;
            Description = libraryDto.Description;
        }
    }
}