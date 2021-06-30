using System;

namespace Article.Api.DTOs
{
    public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public Uri Url { get; set; }
    }
}