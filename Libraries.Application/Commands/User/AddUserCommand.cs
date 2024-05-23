using Libraries.Application.Dtos;
using Libraries.Application.Dtos.User;
using MediatR;

namespace Libraries.Application.Commands.User
{
    public class AddUserCommand : IRequest<UserDto>
    {
        public int? LibraryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public AddUserCommand(AddUserDto user)
        {
            LibraryId = user.LibraryId;
            Name = user.Name;
            Email = user.Email;
        }
    }
}