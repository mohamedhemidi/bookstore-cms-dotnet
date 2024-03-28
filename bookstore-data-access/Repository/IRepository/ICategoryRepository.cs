using bookstore.bookstore_data_access;
using bookstore.bookstore_models;

namespace bookstore_data_access;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    void Save();

}
