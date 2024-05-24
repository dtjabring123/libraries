using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.User
{
    public class AddUserToLibraryCommand : IRequest<UserDto>
    {
        public int UserId { get; set; }
        public int LibraryId { get; set; }

        public AddUserToLibraryCommand(int userId, int libraryId)
        {
            UserId = userId;
            LibraryId = libraryId;
        }
    }
}