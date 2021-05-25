namespace BooksCatalog.Api.Models.Responses
{
    public class UploadImageResponse
    {
        public string Uri { get; set; }
        public string Name { get; set; }

        public UploadImageResponse(string uri, string name)
        {
            Uri = uri;
            Name = name;
        }

        public UploadImageResponse()
        {
        }
    }
}