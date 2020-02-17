using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItechartProj.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
            
        }
        [EnableCors]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetUsers();
            return Ok(users);
        }
        [EnableCors]
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            try
            {
                await userService.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [EnableCors]
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> CheckUser([FromBody]User user)
        {
            try
            {
                var response = await userService.CheckUser(user);
                if (response != null) return Ok(response);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}