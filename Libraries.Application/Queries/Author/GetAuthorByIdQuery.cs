using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Queries.Author
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}