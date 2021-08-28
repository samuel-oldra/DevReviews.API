using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository) =>
            this.repository = repository;

        public async Task<List<Product>> GetAllAsync() =>
            await this.repository.GetAllAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await this.repository.GetByIdAsync(id);

        public async Task<Product> GetDetailsByIdAsync(int id) =>
            await this.repository.GetDetailsByIdAsync(id);

        public async Task<ProductReview> GetReviewByIdAsync(int id) =>
            await this.repository.GetReviewByIdAsync(id);

        public async Task<Product> AddAsync(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            await this.repository.AddAsync(product);

            return product;
        }

        public async Task<Product> UpdateAsync(Product product, UpdateProductInputModel model)
        {
            product.Update(model.Description, model.Price);

            await this.repository.UpdateAsync(product);

            return product;
        }

        public async Task<ProductReview> AddReviewAsync(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await this.repository.AddReviewAsync(productReview);

            return productReview;
        }
    }
}