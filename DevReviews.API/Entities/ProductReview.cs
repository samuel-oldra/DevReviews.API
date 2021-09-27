using System;

namespace DevReviews.API.Entities
{
    public class ProductReview
    {
        public int Id { get; private set; }

        public string Author { get; private set; }

        public int Rating { get; private set; }

        public string Comments { get; private set; }

        public int ProductId { get; private set; }

        public DateTime RegisteredAt { get; private set; }

        public ProductReview(string author, int rating, string comments, int productId)
        {
            this.Author = author;
            this.Rating = rating;
            this.Comments = comments;
            this.ProductId = productId;

            this.RegisteredAt = DateTime.Now;
        }
    }
}