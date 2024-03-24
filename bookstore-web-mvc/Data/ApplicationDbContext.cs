using Microsoft.EntityFrameworkCore;

namespace bookstore_web_mvc;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category {Id = 1, Name="Sci-fi", DisplayOrder=2},
            new Category {Id = 2, Name="Novels", DisplayOrder=7},
            new Category {Id = 3, Name="Action", DisplayOrder=3}
        );
    }
}

