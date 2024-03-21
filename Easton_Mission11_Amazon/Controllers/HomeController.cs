using Easton_Mission11_Amazon.Models;
using Easton_Mission11_Amazon.Models.ViewModels;
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

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var Blah = new ProjectsListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };
            
           

            return View(Blah);
        }

    }
}
