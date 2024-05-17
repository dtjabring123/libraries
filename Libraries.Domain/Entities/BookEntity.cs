namespace Libraries.Domain.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int LibraryId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int UserWithBook { get; set; }
        public int LibraryWithBook { get; set; }

        public AuthorEntity Author { get; set; } = null;
        public LibraryEntity Library { get; set; } = null;

        public bool IsDeleted { get; set; }
    }
}