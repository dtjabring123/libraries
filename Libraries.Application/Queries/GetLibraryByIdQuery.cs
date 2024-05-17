using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Queries
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