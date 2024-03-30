using bookstore.bookstore_data_access.Data;
using bookstore.bookstore_models;
using bookstore.bookstore_models.ViewModels;
using bookstore_data_access;
using bookstore_models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookstore_web_mvc;

[Area("Admin")]
public class BookController : Controller
{
    private readonly IBookRepository _bookRepo;
    private readonly ICategoryRepository _categoryRepo;
    /*
    * GET Categories List
    */
    public BookController(IBookRepository db, ICategoryRepository categoryDb)
    {
        _bookRepo = db;
        _categoryRepo = categoryDb;
    }
    public IActionResult Index()
    {
        List<Book> objBooksList = _bookRepo.GetAll().ToList();
        return View(objBooksList);
    }
    /*
    * CREATE/EDIT Book
    */
    public IActionResult Upsert(int? id)
    {

        BookVM bookVM = new()
        {
            CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }),
            Book = new Book()
        };
        if (id is null || id == 0)
        {
            // CREATE
            return View(bookVM);
        }
        else
        {
            // UPDATE
            bookVM.Book = _bookRepo.Get(u => u.Id == id);
            return View(bookVM);
        }

    }
    [HttpPost]
    public IActionResult Upsert(BookVM bookVM, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            _bookRepo.Add(bookVM.Book);
            _bookRepo.Save();
            TempData["success"] = "Book created successfully!";
            return RedirectToAction("Index", "Book");
        }
        else
        {

            bookVM.CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(bookVM);
        }

    }

    /*
    * DELETE Category
    */
    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        Book book = _bookRepo.Get(u => u.Id == id);

        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Book book = _bookRepo.Get(u => u.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        _bookRepo.Remove(book);
        _bookRepo.Save();
        TempData["success"] = "Book deleted successfully!";
        return RedirectToAction("Index", "Book");
    }
}
