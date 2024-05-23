using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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