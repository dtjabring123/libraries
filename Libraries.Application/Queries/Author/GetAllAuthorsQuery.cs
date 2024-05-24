using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Queries.Author
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
    {
    }
}