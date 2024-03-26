using bookstore.bookstore_data_access.Data;
using bookstore.bookstore_models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookstore_web_mvc;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    /*
    * GET Categories List
    */
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> objCategoriesList = _db.Categories.ToList();
        return View(objCategoriesList);
    }
    /*
    * CREATE Category
    */
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }
        return View();
    }
    /*
    * EDIT Category
    */
    public IActionResult Edit(int? id)
    {
        if(id == 0 || id == null) {
            return NotFound();
        }
        // Works only on Primary Key :
        Category category = _db.Categories.Find(id);
        
        // Works on any Condition :
        //Category category = _db.Categories.FirstOrDefault(u => u.Id == id);
        
        if(category == null) {
            return NotFound();
        }
        return View(category);
    }
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index", "Category");
        }
        return View();
    }
    /*
    * DELETE Category
    */
    public IActionResult Delete(int? id)
    {
        if(id == 0 || id == null) {
            return NotFound();
        }
        // Works only on Primary Key :
        Category category = _db.Categories.Find(id);
                
        if(category == null) {
            return NotFound();
        }
        return View(category);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category category = _db.Categories.Find(id);
        if(category == null) {
            return NotFound();
        }
        _db.Categories.Remove(category);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully!";
        return RedirectToAction("Index", "Category");
    }
}
