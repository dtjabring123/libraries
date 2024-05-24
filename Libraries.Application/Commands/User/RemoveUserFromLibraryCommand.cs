using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.User
{
    public class RemoveUserFromLibraryCommand : IRequest<UserDto>
    {
        public int Id { get; set; }

        public RemoveUserFromLibraryCommand(int id)
        {
            Id = id;
        }
    }
}