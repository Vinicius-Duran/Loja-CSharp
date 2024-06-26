using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Persistencias
{
    public class APIContextoFactory : IDesignTimeDbContextFactory<APIContexto>
    {
        public APIContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<APIContexto>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "API", "appsettings.json"))  
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new APIContexto(optionsBuilder.Options);
        }
    }
}
