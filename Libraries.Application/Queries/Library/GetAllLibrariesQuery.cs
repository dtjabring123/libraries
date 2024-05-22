using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Queries.Library
{
    public class GetAllLibrariesQuery : IRequest<IEnumerable<LibraryDto>>
    {
    }
}