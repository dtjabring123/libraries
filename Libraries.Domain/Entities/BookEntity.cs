namespace Libraries.Domain.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int? LibraryId { get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsCheckedOut { get; set; }
        public bool IsReserved { get; set; }

        public AuthorEntity Author { get; set; } = null;
        public LibraryEntity? Library { get; set; }
        public UserEntity? User { get; set; }

        public bool IsDeleted { get; set; }
    }
}