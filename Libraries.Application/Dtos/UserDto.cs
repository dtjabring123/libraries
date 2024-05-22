﻿namespace Libraries.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public LibraryDto? Library { get; set; }
    }
}