using bookstore.bookstore_models;
using bookstore_models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bookstore.bookstore_data_access.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Sci-fi", DisplayOrder = 2 },
            new Category { Id = 2, Name = "Novels", DisplayOrder = 7 },
            new Category { Id = 3, Name = "Action", DisplayOrder = 3 }
        );
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "1084Q", Price = 2, Stock = 3, Author = "Haruki Murakami", CategoryId = 2 },
            new Book { Id = 2, Title = "Art of War", Price = 3, Stock = 1, Author = "Sun Tzu", CategoryId = 2 },
            new Book { Id = 3, Title = "Shock Doctrine", Price = 1, Stock = 2, Author = "Naomi Klein", CategoryId = 1 }
        );
    }
}

