namespace Easton_Mission11_Amazon.Models
{
    public class EFAmazonRepository: IAmazonRepository
    {
        private BookstoreContext _bookstoreContext;
        public EFAmazonRepository(BookstoreContext temp)
        {
            _bookstoreContext = temp;
        }

        public IQueryable<Book> Books => _bookstoreContext.Books;
    }
}
