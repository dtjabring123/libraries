using Libraries.Application.Dtos.Library;

namespace Libraries.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public int? LibraryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}