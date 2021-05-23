using System.Collections.Generic;
using BooksCatalog.Core.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Core.Authors
{
    public class Author : Entity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}