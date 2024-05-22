using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.Library
{
    public class UpdateLibraryCommand : IRequest<LibraryDto>
    {
        public string Description { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public UpdateLibraryCommand(LibraryDto library)
        {
            Id = library.Id;
            Name = library.Name;
            Description = library.Description;
        }
    }
}