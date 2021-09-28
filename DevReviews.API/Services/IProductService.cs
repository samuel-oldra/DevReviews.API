using DevReviews.API.Entities;
using DevReviews.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> GetDetailsByIdAsync(int id);

        Task<ProductReview> GetReviewByIdAsync(int id);

        Task<Product> AddAsync(AddProductInputModel model);

        Task<Product> UpdateAsync(Product product, UpdateProductInputModel model);

        Task<ProductReview> AddReviewAsync(int productId, AddProductReviewInputModel model);
    }
}