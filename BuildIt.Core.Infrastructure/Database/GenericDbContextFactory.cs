using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BuildIt.Core.Infrastructure.Database
{
    public class GenericDbContextFactory : IDesignTimeDbContextFactory<GenericDbContext>
    {
        public GenericDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GenericDbContext>();
            optionsBuilder.UseMySql("server=localhost;port=3306;database=test;user=root;password=Azerty@123");

            return new GenericDbContext(optionsBuilder.Options);
        }
    }
}