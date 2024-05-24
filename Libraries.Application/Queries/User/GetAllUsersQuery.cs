using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Queries.User
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        public int LibraryId { get; set; }

        public GetAllUsersQuery(int libraryId = 0)
        {
            LibraryId = libraryId;
        }
    }
}