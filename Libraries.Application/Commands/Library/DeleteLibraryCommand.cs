using Libraries.Application.Dtos.Library;
using MediatR;

namespace Libraries.Application.Commands.Library
{
    public class DeleteLibraryCommand : IRequest<LibraryDto>
    {
        public int Id { get; set; }

        public DeleteLibraryCommand(int id)
        {
            Id = id;
        }
    }
}