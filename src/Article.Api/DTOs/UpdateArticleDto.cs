using System;

namespace Article.Api.DTOs
{
    public class UpdateArticleDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public Uri Url { get; set; }
    }
}