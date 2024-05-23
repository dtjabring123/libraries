namespace Libraries.Application.Dtos.User
{
    public class AddUserDto
    {
        public int? LibraryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}