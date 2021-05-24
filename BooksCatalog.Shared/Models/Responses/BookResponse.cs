﻿using System;
using System.Collections.Generic;

namespace BooksCatalog.Shared.Models.Responses
{
    public class BookResponse
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public List<AuthorResponse> Authors { get; set; }
        public List<GenreResponse> Genres { get; set; }
        public List<PublisherResponse> Publishers { get; set; }
    }
}