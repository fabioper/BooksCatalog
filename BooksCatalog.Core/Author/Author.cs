using System;
using System.Collections.Generic;
using BooksCatalog.Core.Books;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Core.Author
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUri { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }

        public Author(string firstName, string lastName, string imageUri, DateTime birthDate)
        {
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            
            FirstName = firstName;
            LastName = lastName;
            ImageUri = imageUri;
            BirthDate = birthDate;
            Books = new List<Book>();
        }

        public Author() // Ef required
        {
        }

        public ICollection<Book> Books { get; set; }
    }
}