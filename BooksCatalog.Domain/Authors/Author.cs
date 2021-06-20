using System;
using System.Collections.Generic;
using BooksCatalog.Domain.Books;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Domain.Authors
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }

        public Author(string name, string imageUri, DateTime birthDate, string biography)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            
            Name = name;
            ImageUri = imageUri;
            BirthDate = birthDate;
            Biography = biography;
            Books = new List<Book>();
        }

        public Author() // Ef required
        {
        }

        public ICollection<Book> Books { get; set; }
    }
}