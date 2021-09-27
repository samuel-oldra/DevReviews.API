using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class UpdateProductInputModel
    {
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}