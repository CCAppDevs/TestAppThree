using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestAppThree.Data;
using TestAppThree.Models;

namespace TestAppThree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        public IActionResult Index()
        {
            List<NewsItem> news = _context.NewsItems.ToList();
            return View(news);
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
}