using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class AddProductInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}