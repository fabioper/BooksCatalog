using System;

namespace BooksCatalog.Api.Models.Requests
{
    public class UpdateAuthorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUri { get; set; }
        public string Biography { get; set; }
    }
}