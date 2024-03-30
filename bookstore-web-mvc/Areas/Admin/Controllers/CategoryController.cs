using bookstore.bookstore_data_access.Data;
using bookstore.bookstore_models;
using bookstore_data_access;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_web_mvc;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepo;
    /*
    * GET Categories List
    */
    public CategoryController(ICategoryRepository db)
    {
        _categoryRepo = db;
    }
    public IActionResult Index()
    {
        List<Category> objCategoriesList = _categoryRepo.GetAll().ToList();
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
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
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
        Category category = _categoryRepo.Get(u => u.Id == id);
                
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
            _categoryRepo.Update(obj);
            _categoryRepo.Save();
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
        Category category = _categoryRepo.Get(u => u.Id == id);
                
        if(category == null) {
            return NotFound();
        }
        return View(category);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category category =_categoryRepo.Get(u => u.Id == id);
        if(category == null) {
            return NotFound();
        }
        _categoryRepo.Remove(category);
        _categoryRepo.Save();
        TempData["success"] = "Category deleted successfully!";
        return RedirectToAction("Index", "Category");
    }
}
