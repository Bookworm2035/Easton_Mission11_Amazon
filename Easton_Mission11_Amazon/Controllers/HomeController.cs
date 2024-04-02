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

        public IActionResult Index(int pageNum, string? bookType)
        {
            int pageSize = 10;
            var Blah = new ProjectsListViewModel
            {
                Books = _repo.Books
                    .Where(x => x.Category == bookType || bookType == null)
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookType == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == bookType).Count()
                },

                CurrentBookType = bookType
            };
            
           

            return View(Blah);
        }

    }
}
