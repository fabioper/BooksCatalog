using System;

namespace BooksCatalog.Api.Models.Requests
{
    public class AddAuthorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUri { get; set; }
        public string Biography { get; set; }
    }
}