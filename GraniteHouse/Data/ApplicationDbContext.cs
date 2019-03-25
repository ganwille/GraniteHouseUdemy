using GraniteHouse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AddSpecialTagsData(builder);
            AddProductTypesData(builder);
            base.OnModelCreating(builder);
        }

        private void AddSpecialTagsData(ModelBuilder builder)
        {
            builder.Entity<SpecialTags>().HasData(
                new SpecialTags { Id = 1, Name = "Best Seller" },
                new SpecialTags { Id = 2, Name = "Highest Rated" },
                new SpecialTags { Id = 3, Name = "New Edition" },
                new SpecialTags { Id = 4, Name = "Special Sale!" });
        }

        private void AddProductTypesData(ModelBuilder builder)
        {
            builder.Entity<ProductTypes>().HasData(
                new ProductTypes { Id = 1, Name = "Granite" },
                new ProductTypes { Id = 2, Name = "Quartz" });
        }

        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<SpecialTags> SpecialTags { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
