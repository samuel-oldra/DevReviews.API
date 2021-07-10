using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DevReviews.API.Entities;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext
    {
        public List<Product> Products { get; set; }

        public DevReviewsDbContext()
        {
            this.Products = new List<Product>();
        }
    }
}