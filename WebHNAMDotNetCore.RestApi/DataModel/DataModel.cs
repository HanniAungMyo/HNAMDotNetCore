namespace WebHNAMDotNetCore.RestApi.DataModel
{
    public class DataModel
    {
        public int BlogId { get; set; }

        public string? BlogTitle { get; set; } 

        public string? BlogAuthor { get; set; }

        public string? BlogContent { get; set; }

        public bool? DeleteFlag { get; set; }
    }
}
