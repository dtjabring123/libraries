{
namespace Libraries.Domain.Entities

    public class AuthorEntity
{
    public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
    public string Description { get; set; } = string.Empty;
    public int Id { get; set; }

    public bool IsDeleted { get; set; }
    public string Name { get; set; } = string.Empty;
}
}