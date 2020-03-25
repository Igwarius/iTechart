using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Route("sort-news/{sortparam}")]
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

        [HttpPost]
        [Route("news")]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            await _newsService.AddNews(news);
            return Ok();
        }
    }
}