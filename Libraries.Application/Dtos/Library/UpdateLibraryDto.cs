namespace Libraries.Application.Dtos.Library
{
    public class UpdateLibraryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}