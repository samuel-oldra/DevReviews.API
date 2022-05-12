using System;
using System.Collections.Generic;

namespace DevReviews.API.Entities
{
    public class Product
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public DateTime RegisteredAt { get; private set; }

        public List<ProductReview> Reviews { get; private set; }

        public Product(string title, string description, decimal price)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;

            this.RegisteredAt = DateTime.Now;
            this.Reviews = new List<ProductReview>();
        }

        public void AddReview(ProductReview review) => Reviews.Add(review);

        public void Update(string description, decimal price)
        {
            this.Description = description;
            this.Price = price;
        }
    }
}