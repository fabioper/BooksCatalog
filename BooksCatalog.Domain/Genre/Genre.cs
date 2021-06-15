using System.Collections.Generic;
using BooksCatalog.Domain.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Domain.Genre
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}