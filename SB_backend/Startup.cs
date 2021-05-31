using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SB_backend.Interfaces;
using SB_backend.Models;
using SB_backend.Repositories;

namespace SB_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ICaracterRepository, CaracterRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            //services.AddScoped<IPositionPlayerRepository, PositionPlayerRepository>();
            services.AddScoped<ITeamSerieRepository, TeamSerieRepository>();
            services.AddScoped<ITeamSeriePlayerRepository, TeamSeriePlayerRepository>();
            services.AddScoped<ITeamSerieDirectorRepository, TeamSerieDirectorRepository>();
            //services.AddScoped<IPitcherRepository, PitcherRepository>();
            services.AddScoped<IStarPositionPlayerSerieRepository, StarPositionPlayerSerieRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPlayerGameRepository, PlayerGameRepository>();
            services.AddScoped<IPlayerChangeGameRepository, PlayerChangeGameRepository>();
            services.AddDbContext<AppDBContext>(options =>
               options.UseSqlServer(Configuration["Data:Baseball:ConnectionString"]));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();  
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseMvc();
        }
    }
}
