namespace Libraries.Domain.Entities
{
    public class UserEntity
    {
        public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
        public string Email { get; set; } = string.Empty;
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public LibraryEntity? Library { get; set; }
        public int? LibraryId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}