using System.ComponentModel.DataAnnotations;

namespace bookstore_models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
}
