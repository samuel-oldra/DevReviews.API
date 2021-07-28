using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class ProductReviewDetailsViewModel
    {
        public int Id { get; private set; }

        public string Author { get; private set; }

        public int Rating { get; private set; }

        public string Comments { get; private set; }

        public DateTime RegisteredAt { get; private set; }
    }
}