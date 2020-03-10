using ItechartProj.DAL.Models;
using ItechartProj.Services.Interfaces;
using ItechartProj.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ItechartProj
{
    public class AccountRequirement : IAuthorizationRequirement
 { }

    public class AuthFilter : AuthorizationHandler<AccountRequirement>
    {
        private readonly IRefreshTokensService refreshTokensService;
        private readonly IHttpContextAccessor httpContextAccessor;
        protected string role;

        public AuthFilter() { }

        public AuthFilter(IRefreshTokensService refreshTokensService, IHttpContextAccessor httpContextAccessor)
        {
            this.refreshTokensService = refreshTokensService;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountRequirement requirement)
        {
            try
            {
                string jwtToken, refreshtoken;

                HttpContext httpContext = httpContextAccessor.HttpContext;
                jwtToken = httpContext.Request.Headers["access_token"];
                 
                refreshtoken = httpContext.Request.Headers["RefreshToken"];

                if (jwtToken == "null" || refreshtoken == "null")
                {
                    context.Fail();
                    httpContext.Response.StatusCode = 401;
                    return;
                }

                var claims = TokenService.VerifyToken(jwtToken);

                if (claims == null)
                {
                    var principal = ClaimsService.GetPrincipalFromExpiredToken(jwtToken);

                    var login = principal.Identity.Name;
                    var role = principal.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
                   

                    var savedRefreshToken = await refreshTokensService.GetRefreshToken(login);
                

                    var identity = ClaimsService.GetIdentity(new User
                    {
                        Login = login,
                        
                        Role = role
                    });

                    var token = TokenService.CreateToken(identity);
                    var newRefreshToken = TokenService.GenerateRefreshToken();
                    await refreshTokensService.DeleteRefreshToken(login);
                    await refreshTokensService.SaveRefreshToken(login, newRefreshToken);

                    var propertyInfo = token.GetType().GetProperty("access_token");
                    string temp = (string)propertyInfo.GetValue(token, null);

                    httpContext.Response.Headers["AccessToken"] = temp;
                    httpContext.Request.Headers["Authorization"] = "Bearer " + temp;
                    httpContext.Response.Headers["RefreshToken"] = newRefreshToken;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            context.Succeed(requirement);
            await Task.Yield();
        }
    }
}