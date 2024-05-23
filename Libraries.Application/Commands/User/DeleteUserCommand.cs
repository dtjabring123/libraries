using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}