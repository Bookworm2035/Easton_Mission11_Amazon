using Easton_Mission11_Amazon.Models;
using Microsoft.AspNetCore.Mvc;
namespace Easton_Mission11_Amazon.Components

{
    public class BookTypesViewComponent : ViewComponent
    {
        private IAmazonRepository _repo;
        public BookTypesViewComponent(IAmazonRepository temp) 
        { 
            _repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedBookType = RouteData?.Values["bookType"];
            var bookTypes = _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(bookTypes);
        }
    }
}
