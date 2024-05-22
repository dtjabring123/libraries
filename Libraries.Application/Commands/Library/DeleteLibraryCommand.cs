using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.Library
{
    public class DeleteLibraryCommand : IRequest<LibraryDto>
    {
        public DeleteLibraryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}