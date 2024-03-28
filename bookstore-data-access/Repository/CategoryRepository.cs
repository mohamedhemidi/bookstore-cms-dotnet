using System.Linq.Expressions;
using bookstore.bookstore_data_access;
using bookstore.bookstore_data_access.Data;
using bookstore.bookstore_models;

namespace bookstore_data_access;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    
    public void Save()
    {
        _db.SaveChanges();
    }
    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }

}
