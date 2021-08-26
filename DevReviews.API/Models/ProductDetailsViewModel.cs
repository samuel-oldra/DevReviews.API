using System;
using System.Collections.Generic;

namespace DevReviews.API.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public DateTime RegisteredAt { get; private set; }

        public List<ProductReviewViewModel> Reviews { get; private set; }

        public ProductDetailsViewModel(
            int id,
            string title,
            string description,
            decimal price,
            DateTime registeredAt,
            List<ProductReviewViewModel> reviews)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.RegisteredAt = registeredAt;
            this.Reviews = reviews;
        }
    }

    public class ProductReviewViewModel
    {
        public int Id { get; private set; }

        public string Author { get; private set; }

        public int Rating { get; private set; }

        public string Comments { get; private set; }

        public DateTime RegisteredAt { get; private set; }

        public ProductReviewViewModel(
            int id,
            string author,
            int rating,
            string comments,
            DateTime registeredAt)
        {
            this.Id = id;
            this.Author = author;
            this.Rating = rating;
            this.Comments = comments;
            this.RegisteredAt = registeredAt;
        }
    }
}