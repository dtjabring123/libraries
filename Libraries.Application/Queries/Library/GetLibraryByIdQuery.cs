using Libraries.Application.Dtos.Library;
using MediatR;

namespace Libraries.Application.Queries.Library
{
    public class GetLibraryByIdQuery : IRequest<LibraryDto>
    {
        public int Id { get; set; }

        public GetLibraryByIdQuery(int id)
        {
            Id = id;
        }
    }
}