using Libraries.Application.Dtos.Library;
using MediatR;

namespace Libraries.Application.Queries.Library
{
    public class GetAllLibrariesQuery : IRequest<IEnumerable<LibraryDto>>
    {
    }
}