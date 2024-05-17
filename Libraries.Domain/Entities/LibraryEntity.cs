﻿namespace Libraries.Domain.Entities
{
    public class LibraryEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();

        public bool IsDeleted { get; set; }
    }
}