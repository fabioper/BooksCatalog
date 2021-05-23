using System.Collections.Generic;
using BooksCatalog.Core.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Core.Publishers
{
    public class Publisher : Entity
    {
        public ICollection<Book> Books { get; set; }
    }
}