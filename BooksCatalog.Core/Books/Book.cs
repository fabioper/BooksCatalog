using System;
using System.Collections.Generic;
using System.Linq;
using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Publishers;
using BooksCatalog.Shared;

namespace BooksCatalog.Core.Books
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Description { get; private set; }
        public string Isbn { get; private set; }

        public ICollection<Author> Authors { get; private set; }
        public ICollection<Genre> Genres { get; private set; }
        public ICollection<Publisher> Publishers { get; private set; }

        public Book(string title, DateTime releaseDate, string description, string isbn, IEnumerable<Author> authors,
            IEnumerable<Genre> genres, IEnumerable<Publisher> publishers)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrEmpty(isbn, nameof(isbn));
            /*Guard.Against.InvalidIsbn(isbn);*/

            Title = title;
            ReleaseDate = releaseDate;
            Description = description;
            Isbn = isbn;
            Authors = authors.ToList();
            Genres = genres.ToList();
            Publishers = publishers.ToList();
        }
    }
}