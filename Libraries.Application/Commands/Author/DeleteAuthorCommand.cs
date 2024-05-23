using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.Author
{
    public class DeleteAuthorCommand : IRequest<AuthorDto>
    {
        public int Id { get; set; }

        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }
    }
}