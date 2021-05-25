using System;
using System.Collections.Generic;

namespace BooksCatalog.Api.Models.Requests
{
    public class AddNewBookRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Isbn { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> PublisherIds { get; set; }
        public string CoverUri { get; set; }
    }
}