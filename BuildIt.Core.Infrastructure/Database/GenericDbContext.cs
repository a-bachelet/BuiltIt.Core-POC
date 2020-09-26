using System.Linq;
using BuildIt.Core.Domain.Services.Classes;
using Microsoft.EntityFrameworkCore;

namespace BuildIt.Core.Infrastructure.Database
{
    public class GenericDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMethod = typeof(ModelBuilder).GetMethod("Entity");

            var assembly = GenericDataService.GetGenericAssembly();
            
            var entityTypes = assembly
                .GetTypes()
                .Where(x => !x.IsAbstract);
            
            foreach (var type in entityTypes)
            {
                entityMethod?.MakeGenericMethod(type)
                    .Invoke(modelBuilder, new object[] { });
            }
        }
        
        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }
    }
}