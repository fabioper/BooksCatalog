using System;
using System.Collections.Generic;

namespace BooksCatalog.Shared.Models.Responses
{
    public class BookResponse
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Publishers { get; set; }
    }
}