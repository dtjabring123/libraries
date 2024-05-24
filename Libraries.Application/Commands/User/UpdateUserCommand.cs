using Libraries.Application.Dtos;
using Libraries.Application.Dtos.User;
using MediatR;

namespace Libraries.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UpdateUserCommand(UpdateUserDto user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}