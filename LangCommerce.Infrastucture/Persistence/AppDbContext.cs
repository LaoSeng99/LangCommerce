
using LangCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LangCommerce.Infrastucture.Persistence;

internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    internal DbSet<Language> Languages { get; set; }
    internal DbSet<Product> Products { get; set; }
    internal DbSet<ProductTranslation> ProductTranslations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductTranslation>(entity =>
        {
            //Each product translation must have a unique combination of ProductId and LanguageCode
            entity.HasIndex(c => new { c.ProductId, c.LanguageCode });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Price)
            .HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Language>(entity =>
        {
        });
    }
}
