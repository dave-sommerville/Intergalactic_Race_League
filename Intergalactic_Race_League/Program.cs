using Microsoft.EntityFrameworkCore;
using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;
using System;
using Intergalactic_Race_League.BLL;

namespace Intergalactic_Race_League
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Configure EF Core with SQL Server
            builder.Services.AddDbContext<IrlDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<RacerRepository>();
            builder.Services.AddScoped<RacerVehicleRepository>();
            builder.Services.AddScoped<VehicleRepository>();
            builder.Services.AddScoped<RaceRepository>();
            builder.Services.AddScoped<TournamentRepository>();

            builder.Services.AddScoped<RacerVehicleService>();
            builder.Services.AddScoped<RacerService>();
            builder.Services.AddScoped<VehicleService>();
            builder.Services.AddScoped<RaceService>();
            builder.Services.AddScoped<TournamentService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
