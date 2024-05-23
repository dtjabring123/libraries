using Libraries.Application.Dtos.Library;
using MediatR;

namespace Libraries.Application.Commands.Library
{
    public class UpdateLibraryCommand : IRequest<LibraryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public UpdateLibraryCommand(UpdateLibraryDto library)
        {
            Id = library.Id;
            Name = library.Name;
            Description = library.Description;
        }
    }
}