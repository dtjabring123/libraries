namespace Libraries.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public int? LibraryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public LibraryEntity? Library { get; set; }

        public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();

        public bool IsDeleted { get; set; }
    }
}