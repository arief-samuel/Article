using System.Linq;
using System.Threading.Tasks;
using Article.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleDbContext _context;

        public ArticlesController(ArticleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _context.Articles.ToListAsync();
            return Ok(articles);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _context.Articles.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (article is null)
                return NotFound();

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Models.Article article)
        {
            if (!ModelState.IsValid)
                return new JsonResult("Something went wrong") { StatusCode = 500 };

            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticle), new { article.Id }, article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, Models.Article article)
        {
            var existingArticle = await _context.Articles.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (article is null)
                return NotFound();

            if (!ModelState.IsValid)
                return new JsonResult("Something went wrong") { StatusCode = 500 };

            existingArticle.Title = article.Title;
            existingArticle.Category = article.Category;
            existingArticle.Url = article.Url;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (article is null)
                return NotFound();

            if (!ModelState.IsValid)
                return new JsonResult("Something went wrong") { StatusCode = 500 };

            _context.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}