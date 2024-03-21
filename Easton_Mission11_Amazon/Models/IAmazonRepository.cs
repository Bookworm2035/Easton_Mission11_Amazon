namespace Easton_Mission11_Amazon.Models
{
    public interface IAmazonRepository

    {
        public IQueryable<Book> Books { get; } 
    }
}
