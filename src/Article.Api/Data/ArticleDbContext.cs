using Article.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.Data
{
    public class ArticleDbContext : DbContext
    {
        public virtual DbSet<Models.Article> Articles { get; set; }

        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
            : base(options)
        {

        }
    }
}