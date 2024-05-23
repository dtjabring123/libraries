using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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