using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookstore_web_razor;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100")]
    public int DisplayOrder { get; set; }
}
