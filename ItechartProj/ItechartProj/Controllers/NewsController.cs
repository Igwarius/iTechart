using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Controllers
{
    [Route("api/News")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService, ICommentService commentService)
        {
            this._newsService = newsService;
            this._commentService = commentService;
        }
    //[Authorize(Policy = "MyPolicy" ) ]
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
            var news  = await _newsService.GetNewsById(id);
            return Ok(news);
        }
        [HttpGet]
        [Route("Comments/{id}")]
        public async Task<IActionResult> GetCommentsForNews(int id)
        {
            var comments = await _commentService.GetCommentsForNews(id);
            return Ok(comments);
        }
        [HttpGet]
        [Route("NewsByCategory/{CategoryID}")]
        public async Task<IActionResult> GetNewsByCategory(int categoryId)
        {
           
            if (categoryId != 0) {
                var news = await _newsService.GetNewsByCategory(categoryId);
                return Ok(news);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("NewsBySubCategory/{SubCategoryID}")]
        public async Task<IActionResult> GetNewsBySubCategory(int subCategoryId)
        {

            if (subCategoryId != 0)
            {
                var news = await _newsService.GetNewsBySubCategory(subCategoryId);
                return Ok(news);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("SortNews/{sortparam}")]
        public async Task<IActionResult> GetSortNews(SortParam sortparam)
        {

            if ((sortparam== SortParam.Date) ||(sortparam == SortParam.View))
            {
                var news = await _newsService.GetSortNews(sortparam);
                return Ok(news);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("SubCategoryByCategory/{CategoryID}")]
        public async Task<IActionResult> GetSubCategoryByCategory(int categoryId)
        {

            if (categoryId != 0)
            {
                var subCategories = await _newsService.GetSubCategoryByCategory(categoryId);
                return Ok(subCategories);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var news = await _newsService.GetCategories();
            return Ok(news);
        }
        [HttpGet]
        [Route("SubCategories")]
        public async Task<IActionResult> GetSubAllCategories()
        {
            var news = await _newsService.GetSubCategories();
            return Ok(news);
        }
        [Authorize(Policy = "MyPolicy")]
        [HttpPost]
        [Route("Comment")]
        public async Task<IActionResult> AddComment([FromBody]Comment comment)
        {
            try
            {
                await _commentService.AddComments(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("News")]
        public async Task<IActionResult> AddNews([FromBody]News news)
        {
            try
            {
                await _newsService.AddNews(news);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
