namespace Libraries.Domain.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();

        public bool IsDeleted { get; set; }
    }
}