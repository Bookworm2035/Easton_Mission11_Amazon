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

    }
}
