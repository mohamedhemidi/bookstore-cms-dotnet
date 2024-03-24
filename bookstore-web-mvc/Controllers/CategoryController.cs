using Microsoft.AspNetCore.Mvc;

namespace bookstore_web_mvc;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> objCategoriesList = _db.Caregories.ToList();
        return View(objCategoriesList);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        _db.Caregories.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index", "Category");
    }

}
