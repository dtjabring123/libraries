namespace Libraries.Domain.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int UserWithBook { get; set; }
        public int LibraryWithBook { get; set; }

        public bool IsDeleted { get; set; }
    }
}