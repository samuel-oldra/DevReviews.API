using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);

                p
                    .HasMany(p => p.Reviews)
                    .WithOne()
                    .HasForeignKey(pr => pr.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductReview>(pr =>
            {
                pr.ToTable("tb_ProductReviews");
                pr.HasKey(pr => pr.Id);

                pr
                    .Property(pr => pr.Author)
                    .HasMaxLength(50)
                    .IsRequired();
            });
        }
    }
}