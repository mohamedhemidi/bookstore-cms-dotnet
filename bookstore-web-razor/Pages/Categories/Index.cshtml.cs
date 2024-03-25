using bookstore_web_razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList {get; set;}

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
