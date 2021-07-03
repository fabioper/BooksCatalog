using System;
using System.Collections.Generic;
using BooksCatalog.Domain.Authors;
using BooksCatalog.Domain.Genres;
using BooksCatalog.Domain.Publishers;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Guards;

namespace BooksCatalog.Domain.Books
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string CoverUri { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Publisher> Publishers { get; set; }

        public Book(string title, DateTime releaseDate, string description, string coverUri, List<Author> authors,
            List<Genre> genres, List<Publisher> publishers)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrEmpty(authors, nameof(authors));
            Guard.Against.NullOrEmpty(genres, nameof(genres));
            Guard.Against.NullOrEmpty(publishers, nameof(publishers));

            Title = title;
            ReleaseDate = releaseDate;
            Description = description;
            CoverUri = coverUri;
            Authors = authors;
            Genres = genres;
            Publishers = publishers;
            CreationDate = DateTime.UtcNow;
        }

        public Book() // EF Core required
        {
        }
    }
}