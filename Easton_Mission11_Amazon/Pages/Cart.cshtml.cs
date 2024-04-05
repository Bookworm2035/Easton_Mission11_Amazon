using Easton_Mission11_Amazon.Infrastructure;
using Easton_Mission11_Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Easton_Mission11_Amazon.Pages
{
    public class CartModel : PageModel
    {
        private IAmazonRepository _repo;
        public CartModel(IAmazonRepository temp)
        {
            _repo = temp;
        }
        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            ReturnUrl = ReturnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
             Book b = _repo.Books
                .FirstOrDefault(x=>x.BookId == bookId);

            if (b != null) 
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(b, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new {returnUrl=returnUrl});

        }
    }
}
