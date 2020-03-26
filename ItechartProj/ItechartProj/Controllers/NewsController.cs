using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Newtonsoft.Json;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Controllers
{
    [Route("News")]
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
        [Route("News")]
        public async Task<IActionResult> GetAllNews()
        {
            var news = await _newsService.GetNews();
            return Ok(news);
        }

        [HttpGet]
        [Route("News/{id}")]
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
            NewsWithComments newsWithComments = new NewsWithComments
            {
                News = news.ToList(),
                Comment = comments.ToList()
            };
            
            string serial = JsonConvert.SerializeObject(newsWithComments).ToLowerInvariant();
            return Ok(serial);
        }

        [HttpGet]
        [Route("news-with-category")]
        public async Task<IActionResult> GetNewsWithCategory()
        {

            var news = await _newsService.GetNews();
            var categories = await _newsService.GetCategories();
            NewsWithCategories newsWithCategories = new NewsWithCategories()
            {
                News = news.ToList(),
                Categories = categories.ToList()
            };
            
            string serial = JsonConvert.SerializeObject(newsWithCategories).ToLowerInvariant();
            return Ok(serial);
        }

        [HttpGet]
        [Route("News-by-category/{CategoryID}")]
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
        [Route("News-by-sub-category/{SubCategoryID}")]
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
        [Route("Comment")]
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
        [Route("News")]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            await _newsService.AddNews(news);
            return Ok();
        }
    }
}