namespace Libraries.Application.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AuthorDto Author { get; set; } = null;
        public LibraryDto? Library { get; set; }
        public UserDto? User { get; set; }

        public bool IsCheckedOut { get; set; }
        public bool IsReserved { get; set; }
    }
}