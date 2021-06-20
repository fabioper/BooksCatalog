using System.Collections.Generic;
using BooksCatalog.Domain.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Domain.Genres
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

        public Genre(string name)
        {
            Name = name;
        }

        public Genre() // EF required
        {
        }
    }
}