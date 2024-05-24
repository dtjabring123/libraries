using Libraries.Application.Dtos.Library;

namespace Libraries.Application.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public int? LibraryId { get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsCheckedOut { get; set; }
        public bool IsReserved { get; set; }
    }
}