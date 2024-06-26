﻿namespace Libraries.Application.Dtos.Book
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}