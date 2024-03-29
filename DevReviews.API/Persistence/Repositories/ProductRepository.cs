using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevReviewsDbContext _dbContext;

        public ProductRepository(DevReviewsDbContext dbContext)
            => this._dbContext = dbContext;

        public async Task<List<Product>> GetAllAsync()
            => await _dbContext.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id)
            => await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

        public async Task<Product> GetDetailsByIdAsync(int id)
            => await _dbContext.Products.Include(p => p.Reviews).SingleOrDefaultAsync(p => p.Id == id);

        public async Task<ProductReview> GetReviewByIdAsync(int id)
            => await _dbContext.ProductReviews.SingleOrDefaultAsync(pr => pr.Id == id);

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReviewAsync(ProductReview productReview)
        {
            await _dbContext.ProductReviews.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();
        }
    }
}