using System.Linq.Expressions;
using bookstore.bookstore_data_access;
using bookstore.bookstore_data_access.Data;
using bookstore.bookstore_models;
using bookstore_models;

namespace bookstore_data_access;

public class BookRepository : Repository<Book>, IBookRepository
{
    private ApplicationDbContext _db;
    public BookRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }


    public void Save()
    {
        _db.SaveChanges();
    }
    public void Update(Book obj)
    {
        // _db.Books.Update(obj);
        var objFromDb = _db.Books.FirstOrDefault(u => u.Id == obj.Id);
        if (objFromDb != null)
        {
            objFromDb.Title = obj.Title;
            objFromDb.ISBN = obj.ISBN;
            objFromDb.Price = obj.Price;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.Author = obj.Author;
            if (obj.ImageUrl != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}
