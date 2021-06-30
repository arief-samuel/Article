using Article.Api.DTOs;

namespace Article.Api
{
    public static class Extension
    {
        public static ArticleDto AsDto(this Models.Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Category = article.Category,
                Url = article.Url,
                Created_At = article.Created_At
            };
        }
    }
}