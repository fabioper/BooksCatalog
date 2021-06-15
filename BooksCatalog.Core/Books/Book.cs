using System;
using System.Collections.Generic;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Core.Books
{
    public class Book : Entity
    {
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public string Description { get; }
        public string Isbn { get; }
        public string CoverUri { get; set; }

        public ICollection<Author.Author> Authors { get; }
        public ICollection<Genre.Genre> Genres { get; }
        public ICollection<Publisher.Publisher> Publishers { get; }

        public Book(string title, DateTime releaseDate, string description, string isbn, List<Author.Author> authors,
            List<Genre.Genre> genres, List<Publisher.Publisher> publishers)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrEmpty(isbn, nameof(isbn));
            /*Guard.Against.NullOrEmpty(authors, nameof(authors));
            Guard.Against.NullOrEmpty(genres, nameof(genres));
            Guard.Against.NullOrEmpty(publishers, nameof(publishers));*/
            /*Guard.Against.InvalidIsbn(isbn);*/

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