using AutoFixture;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using DevReviews.API.Services;
using Moq;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DevReviews.API.Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public async Task GetAllAsync()
        {
            // Arrange
            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var products = await productService.GetAllAsync();

            // Assert
            productRepositoryMock.Verify(pr => pr.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);
            var product = await productService.GetByIdAsync(addedProduct.Id);

            // Assert
            Assert.NotNull(addedProduct);

            addedProduct.ShouldNotBeNull();

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetDetailsByIdAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);
            var product = await productService.GetDetailsByIdAsync(addedProduct.Id);

            // Assert
            Assert.NotNull(addedProduct);

            addedProduct.ShouldNotBeNull();

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetReviewByIdAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);
            var productReview = await productService.GetReviewByIdAsync(addedProduct.Id);

            // Assert
            Assert.NotNull(addedProduct);

            addedProduct.ShouldNotBeNull();

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(pr => pr.GetReviewByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task AddAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);

            // Assert
            Assert.NotNull(addedProduct);
            Assert.Equal(addedProduct.Title, addProductInputModel.Title);
            Assert.Equal(addedProduct.Description, addProductInputModel.Description);
            Assert.Equal(addedProduct.Price, addProductInputModel.Price);

            addedProduct.ShouldNotBeNull();
            addedProduct.Title.ShouldBe(addProductInputModel.Title);
            addedProduct.Description.ShouldBe(addProductInputModel.Description);
            addedProduct.Price.ShouldBe(addProductInputModel.Price);

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();
            var updateProductInputModel = new Fixture().Create<UpdateProductInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);
            var updatedProduct = await productService.UpdateAsync(addedProduct, updateProductInputModel);

            // Assert
            Assert.NotNull(updatedProduct);
            Assert.Equal(updatedProduct.Title, addProductInputModel.Title);
            Assert.Equal(updatedProduct.Description, updateProductInputModel.Description);
            Assert.Equal(updatedProduct.Price, updateProductInputModel.Price);

            updatedProduct.ShouldNotBeNull();
            updatedProduct.Title.ShouldBe(addProductInputModel.Title);
            updatedProduct.Description.ShouldBe(updateProductInputModel.Description);
            updatedProduct.Price.ShouldBe(updateProductInputModel.Price);

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(pr => pr.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task AddReviewAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();
            var addProductReviewInputModel = new Fixture().Create<AddProductReviewInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);
            var addedProductReview = await productService.AddReviewAsync(addedProduct.Id, addProductReviewInputModel);

            // Assert
            Assert.NotNull(addedProduct);
            Assert.NotNull(addedProductReview);
            Assert.Equal(addedProductReview.Rating, addProductReviewInputModel.Rating);
            Assert.Equal(addedProductReview.Author, addProductReviewInputModel.Author);
            Assert.Equal(addedProductReview.Comments, addProductReviewInputModel.Comments);
            Assert.Equal(addedProductReview.ProductId, addedProduct.Id);

            addedProduct.ShouldNotBeNull();
            addedProductReview.ShouldNotBeNull();
            addedProductReview.Rating.ShouldBe(addProductReviewInputModel.Rating);
            addedProductReview.Author.ShouldBe(addProductReviewInputModel.Author);
            addedProductReview.Comments.ShouldBe(addProductReviewInputModel.Comments);
            addedProductReview.ProductId.ShouldBe(addedProduct.Id);

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
            productRepositoryMock.Verify(pr => pr.AddReviewAsync(It.IsAny<ProductReview>()), Times.Once);
        }
    }
}