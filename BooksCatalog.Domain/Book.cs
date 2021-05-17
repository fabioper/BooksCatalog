using System;
using System.ComponentModel.DataAnnotations;

namespace BooksCatalog.Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        [Key]
        public string ISBN { get; set; }
    }
}