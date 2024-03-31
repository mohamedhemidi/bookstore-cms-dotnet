using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookstore.bookstore_models;
using bookstore_data_access;

namespace bookstore_web_mvc.Controllers;
[Area("User")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookRepository _bookRepo;

    public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
    {
        _logger = logger;
        _bookRepo = bookRepository;
    }

    public IActionResult Index()
    {
        IEnumerable<Book> booksList = _bookRepo.GetAll(includeProperties: "Category").ToList();
        return View(booksList);
    }
    public IActionResult Details(int bookId)
    {
        Book book = _bookRepo.Get(u => u.Id == bookId, includeProperties: "Category");
        return View(book);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
