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
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IBookRepository _bookRepo;
    private readonly ICategoryRepository _categoryRepo;
    /*
    * GET Categories List
    */
    public BookController(IBookRepository db, ICategoryRepository categoryDb, IWebHostEnvironment webHostEnvironment)
    {
        _bookRepo = db;
        _categoryRepo = categoryDb;
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        List<Book> objBooksList = _bookRepo.GetAll(includeProperties: "Category").ToList();
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
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string bookPath = Path.Combine(wwwRootPath, @"images/books");

                if (!string.IsNullOrEmpty(bookVM.Book.ImageUrl))
                {
                    //DELETE the old image
                    string oldImagePath =
                        Path.Combine(wwwRootPath, bookVM.Book.ImageUrl.Trim('/'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                bookVM.Book.ImageUrl = @"/images/books/" + fileName;
            }
            if (bookVM.Book.Id == 0)
            {
                _bookRepo.Add(bookVM.Book);
            }
            else
            {
                _bookRepo.Update(bookVM.Book);
            }
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
