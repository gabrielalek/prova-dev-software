﻿using System;

namespace Prova.Csharp.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Author { get; set; }
        public string Editor { get; set; }
        public DateTime CreatedAt { get; set; }
        public Book() => CreatedAt = DateTime.Now;
    }
}