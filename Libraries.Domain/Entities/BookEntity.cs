namespace Libraries.Domain.Entities
{
    public class BookEntity
    {
        public AuthorEntity Author { get; set; } = null;
        public int AuthorId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Id { get; set; }
        public bool IsCheckedOut { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReserved { get; set; }
        public LibraryEntity? Library { get; set; }
        public int? LibraryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public UserEntity? User { get; set; }
        public int? UserId { get; set; }
    }
}