using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ItechartProj.DAL.Context;
using ItechartProj.Services.Interfaces;
using ItechartProj.Services.Services;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.DAL.Repository.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ItechartProj.Services;
using WebServer.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ItechartProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INewsSevice, NewssService>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IRefreshTokensRepository, RefreshTokensRepository>();
            services.AddTransient<IRefreshTokensService, RefreshTokenService>();
         
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                       };
                   });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    
                    policy.Requirements.Add(new AccountRequirement());
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                  //  policy.RequireRole("user");
                });
            });
            services.AddScoped<IAuthorizationHandler, AuthFilter>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors();
         
            services.AddDbContext<Context>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("Context")));
            
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(opts => opts
                 .WithOrigins(
                 "http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }

    }
}
