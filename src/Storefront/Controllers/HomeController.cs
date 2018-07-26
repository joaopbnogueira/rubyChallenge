using System.Diagnostics;
using Cabify.Storefront.Models;
using Cabify.Storefront.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cabify.Storefront.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserContext _context;

        public HomeController(IUserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Name = _context.Name
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
