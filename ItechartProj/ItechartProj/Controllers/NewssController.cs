using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItechartProj.Controllers
{
    [Route("api/News")]
    [ApiController]
    public class NewssController : Controller
    {
        private readonly INewssSevice newsService;
        public NewssController(INewssSevice newssSevice)
        {
            this.newsService = newssSevice;

        }
       
        [HttpGet]
        [Route("GetAllNews")]
        public async Task<IActionResult> GetAllUsers()
        {
            var newss = await newsService.GetNews();
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
