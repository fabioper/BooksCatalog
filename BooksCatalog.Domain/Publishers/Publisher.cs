using System.Collections.Generic;
using BooksCatalog.Domain.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Domain.Publishers
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        
        public Publisher(string name)
        {
            Name = name;
        }

        public ICollection<Book> Books { get; set; }
    }
}