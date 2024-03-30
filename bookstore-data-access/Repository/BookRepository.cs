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
        _db.Books.Update(obj);
    }
}
