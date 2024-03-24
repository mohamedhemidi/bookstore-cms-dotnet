using Microsoft.EntityFrameworkCore;

namespace bookstore_web_mvc;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}
