using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Queries
{
    public class GetAllLibrariesQuery : IRequest<IEnumerable<LibraryDto>>
    {
    }
}