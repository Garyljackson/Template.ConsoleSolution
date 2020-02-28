﻿using System;

namespace Template.ConsoleSolution.ConsoleApp.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}