using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands
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