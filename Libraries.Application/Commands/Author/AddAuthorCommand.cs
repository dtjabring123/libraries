using Libraries.Application.Dtos;
using Libraries.Application.Dtos.Author;
using MediatR;

namespace Libraries.Application.Commands.Author
{
    public class AddAuthorCommand : IRequest<AuthorDto>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AddAuthorCommand(AddAuthorDto author)
        {
            Name = author.Name;
            Description = author.Description;
        }
    }
}