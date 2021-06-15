using System.Collections.Generic;
using BooksCatalog.Domain.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Domain.Publisher
{
    public class Publisher : Entity
    {
        public ICollection<Book> Books { get; set; }
    }
}