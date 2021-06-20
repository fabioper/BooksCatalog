using System;
using System.Collections.Generic;
using BooksCatalog.Domain.Books.Guards;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Domain.Books
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string CoverUri { get; set; }

        public ICollection<Author.Author> Authors { get; set; }
        public ICollection<Genre.Genre> Genres { get; set; }
        public ICollection<Publisher.Publisher> Publishers { get; set; }

        public Book(string title, DateTime releaseDate, string description, string isbn, List<Author.Author> authors,
            List<Genre.Genre> genres, List<Publisher.Publisher> publishers)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrEmpty(isbn, nameof(isbn));
            Guard.Against.NullOrEmpty(authors, nameof(authors));
            Guard.Against.NullOrEmpty(genres, nameof(genres));
            Guard.Against.NullOrEmpty(publishers, nameof(publishers));
            Guard.Against.InvalidIsbn(isbn);

            Title = title;
            ReleaseDate = releaseDate;
            Description = description;
            Isbn = isbn;
            Authors = authors;
            Genres = genres;
            Publishers = publishers;
        }

        public Book() // EF Core required
        {
        }
    }
}