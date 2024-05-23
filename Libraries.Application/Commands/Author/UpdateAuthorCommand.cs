using Libraries.Application.Dtos;
using MediatR;

namespace Libraries.Application.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<AuthorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public UpdateAuthorCommand(UpdateAuthorDto author)
        {
            Id = author.Id;
            Name = author.Name;
            Description = author.Description;
        }
    }
}