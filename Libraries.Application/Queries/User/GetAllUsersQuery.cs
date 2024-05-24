using Libraries.Application.Dtos;
using MediatR;

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