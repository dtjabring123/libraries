using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Queries.Library
{
    public class GetLibraryByIdQuery : IRequest<LibraryDto>
    {
        public GetLibraryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}