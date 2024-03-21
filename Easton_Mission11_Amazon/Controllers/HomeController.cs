using Easton_Mission11_Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Easton_Mission11_Amazon.Controllers
{
    public class HomeController : Controller
    {
        private IAmazonRepository _repo;

        public HomeController(IAmazonRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var projectData = _repo.Books;
            return View(projectData);
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
