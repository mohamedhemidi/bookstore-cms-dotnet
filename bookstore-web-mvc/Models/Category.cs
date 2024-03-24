using System.ComponentModel.DataAnnotations;

namespace bookstore_web_mvc;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int DisplayName { get; set; }
}
