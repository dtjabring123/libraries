namespace Libraries.Application.Dtos
{
    public class AddBookDto
    {
        public int AuthorId { get; set; }
        public int? LibraryId { get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}