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
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserService userService;
        public UserController(IUserService userService, IRefreshTokenService refreshTokenService)
        {
            this.userService = userService;
            this._refreshTokenService = refreshTokenService;
        }
        [EnableCors]
        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetUsers();
            return Ok(users);
        }
        [EnableCors]
        [HttpPost]
        [Route("User")]
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
        [Route("Tokens")]
        public async Task<IActionResult> RefreshToken()
        {
            var token = Request.Headers["AccessToken"];
            var refreshToken = Request.Headers["Token"];

            var principal = ClaimsService.GetPrincipalFromExpiredToken(token);

            var username = principal.Identity.Name;
            

            var savedRefreshToken = await _refreshTokenService.GetRefreshToken(username); //retrieve the refresh token from a data store
            if (savedRefreshToken.Token != refreshToken) return BadRequest("Invalid refresh token");

            var identity = ClaimsService.GetIdentity(new User { Login = username});
            var jwttoken = TokenService.CreateToken(identity);
            var newRefreshToken = TokenService.GenerateRefreshToken();

            await _refreshTokenService.DeleteRefreshToken(username);
            await _refreshTokenService.SaveRefreshToken(username, newRefreshToken);

            object toc = new
            {
                token = jwttoken,
                refreshToken = newRefreshToken
            };

            return Ok(toc);
        }


    }
}