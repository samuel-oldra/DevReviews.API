namespace DevReviews.API.Models
{
    public class ProductViewModel
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public ProductViewModel(
            int id,
            string title,
            decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }
    }
}