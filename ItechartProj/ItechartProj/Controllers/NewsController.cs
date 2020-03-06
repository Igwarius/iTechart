using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Controllers
{
    [Route("api/News")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsSevice newsService;
        public NewsController(INewsSevice newssSevice)
        {
            this.newsService = newssSevice;

        }
   //   [Authorize(Policy = "MyPolicy")]
        [HttpGet]
        [Route("GetAllNews")]
        public async Task<IActionResult> GetAllNews()
        {
            var newss = await newsService.GetNews();
            return Ok(newss);
        }
        [HttpGet]
        [Route("GetNewsById/{Id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var newss = await newsService.GetNewssById(id);
            return Ok(newss);
        }
        [HttpGet]
        [Route("GetNewsByCategory/{CategoryID}")]
        public async Task<IActionResult> GetNewsByCategory(int CategoryID)
        {
           
            if (CategoryID != 0) {
                var newss = await newsService.GetNewsByCategory(CategoryID);
                return Ok(newss);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetNewsBySubCategory/{SubCategoryID}")]
        public async Task<IActionResult> GetNewsBySubCategory(int SubCategoryID)
        {

            if (SubCategoryID != 0)
            {
                var newss = await newsService.GetNewsBySubCategory(SubCategoryID);
                return Ok(newss);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetSortNews/{sortparam}")]
        public async Task<IActionResult> GetSortNews(SortParam sortparam)
        {

            if ((sortparam== SortParam.date) ||(sortparam == SortParam.view))
            {
                var news = await newsService.GetSortNews(sortparam);
                return Ok(news);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetSubCategoryByCategory/{CategoryID}")]
        public async Task<IActionResult> GetSubCategoryByCategory(int CategoryID)
        {

            if (CategoryID != 0)
            {
                var subCategories = await newsService.GetSubCategoryByCategory(CategoryID);
                return Ok(subCategories);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCatigories()
        {
            var newss = await newsService.GetCategories();
            return Ok(newss);
        }
        [HttpGet]
        [Route("GetAllSubCategories")]
        public async Task<IActionResult> GetSubAllCatigories()
        {
            var newss = await newsService.GetSubCategories();
            return Ok(newss);
        }


        [HttpPost]
        [Route("AddNews")]
        public async Task<IActionResult> AddUser([FromBody]News news)
        {
            try
            {
                await newsService.AddNews(news);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
