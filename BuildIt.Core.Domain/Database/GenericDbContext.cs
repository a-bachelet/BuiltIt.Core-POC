using System;
using System.Linq;
using System.Reflection;
using BuildIt.Core.Domain.Attributes;
using BuildIt.Core.Domain.Generic.Classes;
using BuildIt.Core.Domain.Services.Classes;
using Microsoft.EntityFrameworkCore;

namespace BuildIt.Core.Domain.Database
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = GenericDataService.GetGenericAssembly();

            var mainEntityTypes = assembly
                .GetTypes()
                .Where(x => x.BaseType is { } && x.BaseType == typeof(AbstractEntity));
            
            var subEntityTypes = assembly
                .GetTypes()
                .Where(x => x.GetCustomAttributes(typeof(GenericSubEntityAttribute), true).Length > 0);

            foreach (var type in mainEntityTypes) modelBuilder.Entity(type).HasKey("Guid");

            foreach (var type in subEntityTypes)
            {
                modelBuilder.Entity(type).HasKey(type.GetCustomAttribute<GenericSubEntityAttribute>().Keys);
            }
        }
    }
}