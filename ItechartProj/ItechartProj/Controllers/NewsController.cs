using System.Linq;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Controllers
{
    [Route("news")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService, ICommentService commentService)
        {
            _newsService = newsService;
            _commentService = commentService;
        }

        [HttpGet]
        [Route("news")]
        public async Task<IActionResult> GetAllNews()
        {
            var news = await _newsService.GetNews();
            return Ok(news);
        }

        [HttpGet]
        [Route("news/{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await _newsService.GetNewsById(id);
            return Ok(news);
        }

        [HttpGet]
        [Route("comments/{id}")]
        public async Task<IActionResult> GetCommentsForNews(int id)
        {
            var comments = await _commentService.GetCommentsForNews(id);
            return Ok(comments);
        }

        [HttpGet]
        [Route("full-news/{id}")]
        public async Task<IActionResult> GetFullNewsById(int id)
        {
            var news = await _newsService.GetNewsById(id);
            var comments = await _commentService.GetCommentsForNews(id);
            var newsWithComments = new NewsWithComments
            {
                News = news.ToList(),
                Comment = comments.ToList()
            };

            var serial = JsonConvert.SerializeObject(newsWithComments).ToLowerInvariant();
            return Ok(serial);
        }

        [HttpGet]
        [Route("news-with-category")]
        public async Task<IActionResult> GetNewsWithCategory()
        {
            var news = await _newsService.GetNews();
            var categories = await _newsService.GetCategories();
            var newsWithCategories = new NewsWithCategories
            {
                News = news.ToList(),
                Categories = categories.ToList()
            };

            var serial = JsonConvert.SerializeObject(newsWithCategories).ToLowerInvariant();
            return Ok(serial);
        }

        [HttpGet]
        [Route("news-by-category/{CategoryID}")]
        public async Task<IActionResult> GetNewsByCategory(int categoryId)
        {
            if (categoryId >= 0)
            {
                var news = await _newsService.GetNewsByCategory(categoryId);
                return Ok(news);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("news-by-sub-category/{SubCategoryID}")]
        public async Task<IActionResult> GetNewsBySubCategory(int subCategoryId)
        {
            if (subCategoryId >= 0)
            {
                var news = await _newsService.GetNewsBySubCategory(subCategoryId);
                return Ok(news);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("sort-News/{sortparam}")]
        public async Task<IActionResult> GetSortNews(SortParam sortparam)
        {
            var news = await _newsService.GetSortNews(sortparam);
            return Ok(news);
        }

        [HttpGet]
        [Route("sub-category-by-category/{CategoryID}")]
        public async Task<IActionResult> GetSubCategoryByCategory(int categoryId)
        {
            if (categoryId >= 0)
            {
                var subCategories = await _newsService.GetSubCategoryByCategory(categoryId);
                return Ok(subCategories);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var news = await _newsService.GetCategories();
            return Ok(news);
        }

        [HttpGet]
        [Route("sub-categories")]
        public async Task<IActionResult> GetSubAllCategories()
        {
            var news = await _newsService.GetSubCategories();
            return Ok(news);
        }

        [Authorize(Policy = "MyPolicy")]
        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> AddComment([FromBody] Comment comment)
        {
            await _commentService.AddComments(comment);
            return Ok();
        }

        [HttpGet]
        [Route("views/{id}")]
        public async Task<IActionResult> AddViews(int id)
        {
            await _newsService.AddViews(id);
            return Ok();
        }

        [HttpGet]
        [Route("archived-news/{id}")]
        public async Task<IActionResult> ArchivedNews(int id)
        {
            await _newsService.ArchivedNews(id);
            return Ok();
        }

        [HttpGet]
        [Route("rearchived-news/{id}")]
        public async Task<IActionResult> RearchivedNews(int id)
        {
            await _newsService.RearchivedNews(id);
            return Ok();
        }

        [HttpGet]
        [Route("liked/{login}/{id}")]
        public async Task<IActionResult> AddLike(string login, int id)
        {
            await _newsService.AddLike(login, id);
            return Ok();
        }

        [HttpGet]
        [Route("like/{login}/{id}")]
        public async Task<IActionResult> GetLike(string login, int id)
        {
            var like = await _newsService.GetLike(login, id);
            return Ok(like);
        }

        [HttpPost]
        [Route("news")]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            await _newsService.AddNews(news);
            return Ok();
        }

        [HttpDelete]
        [Route("like/{login}/{id}")]
        public async Task<IActionResult> Unlike(string login, int id)
        {
            await _newsService.Unlike(login, id);
            return Ok();
        }
    }
}