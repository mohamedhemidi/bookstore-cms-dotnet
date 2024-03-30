using bookstore.bookstore_data_access;
using bookstore.bookstore_models;
using bookstore_models;

namespace bookstore_data_access;

public interface IBookRepository : IRepository<Book>
{
    void Update(Book obj);
    void Save();

}
