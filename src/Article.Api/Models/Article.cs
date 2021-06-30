using System;

namespace Article.Api.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public Uri Url { get; set; }
        public DateTimeOffset Created_At { get; set; }
    }
}