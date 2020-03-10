using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using ItechartProj.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItechartProj.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRefreshTokensService refreshTokensService;
        private readonly IUserService userService;
        public UserController(IUserService userService, IRefreshTokensService refreshTokensService)
        {
            this.userService = userService;
            this.refreshTokensService = refreshTokensService;
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
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var token = Request.Headers["AccessToken"];
            var refreshToken = Request.Headers["RefreshToken"];

            var principal = ClaimsService.GetPrincipalFromExpiredToken(token);

            var username = principal.Identity.Name;
            

            var savedRefreshToken = await refreshTokensService.GetRefreshToken(username); //retrieve the refresh token from a data store
            if (savedRefreshToken.RefreshToken != refreshToken) return BadRequest("Invalid refresh token");

            var identity = ClaimsService.GetIdentity(new User { Login = username});
            var jwttoken = TokenService.CreateToken(identity);
            var newRefreshToken = TokenService.GenerateRefreshToken();

            await refreshTokensService.DeleteRefreshToken(username);
            await refreshTokensService.SaveRefreshToken(username, newRefreshToken);

            object toc = new
            {
                token = jwttoken,
                refreshToken = newRefreshToken
            };

            return Ok(toc);
        }


    }
}