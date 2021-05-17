using System;

namespace BooksCatalog.Domain.Books
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
    }
}