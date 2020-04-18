using ItechartProj.DAL.Contexts;
using ItechartProj.DAL.Repository.Classes;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services;
using ItechartProj.Services.Interfaces;
using ItechartProj.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebServer.Services.Services;

namespace ItechartProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.Requirements.Add(new AccountRequirement());
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                });
            });
            services.AddScoped<IAuthorizationHandler, AuthFilter>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors();
            
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Context")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc(opt =>
            {
               
                opt.UseCentralRoutePrefix(new RouteAttribute("api/"));

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(opts => opts
                .WithOrigins(
                    "http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}