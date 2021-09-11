namespace DevReviews.API.Models
{
    public class AddProductReviewInputModel
    {
        public int Rating { get; set; }

        public string Author { get; set; }

        public string Comments { get; set; }
    }
}