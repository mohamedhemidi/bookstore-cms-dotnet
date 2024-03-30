using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookstore_models;

namespace bookstore.bookstore_models;

public class Book : Product
{
    public string? ISBN { get; set; }
    public string Author { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
}
