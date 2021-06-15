using System.Collections.Generic;
using BooksCatalog.Core.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Core.Publisher
{
    public class Publisher : Entity
    {
        public ICollection<Book> Books { get; set; }
    }
}