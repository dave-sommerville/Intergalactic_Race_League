using Microsoft.EntityFrameworkCore;
using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<IrlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddScoped<RacerRepository>();
builder.Services.AddScoped<RacerVehicleRepository>();
builder.Services.AddScoped<VehicleRepository>();
builder.Services.AddScoped<TournamentRepository>();
builder.Services.AddScoped<RaceRepository>();
builder.Services.AddScoped<TournamentService>();
builder.Services.AddScoped<RaceService>();
builder.Services.AddScoped<RacerVehicleService>();
builder.Services.AddScoped<RacerService>();
builder.Services.AddScoped<VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
