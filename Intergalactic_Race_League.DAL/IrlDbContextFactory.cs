using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Intergalactic_Race_League.DAL
{
    public class IrlDbContextFactory : IDesignTimeDbContextFactory<IrlDbContext>
    {
        public IrlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IrlDbContext>();

            // Get the configuration from thejson file
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new IrlDbContext(optionsBuilder.Options);
        }
    }
}