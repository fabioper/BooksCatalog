﻿using System;

namespace BooksCatalog.Api.Models.Responses
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUri { get; set; }
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }
    }
}