using AutoFixture;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using DevReviews.API.Services;
using Moq;
using Shouldly;
using Xunit;

namespace DevReviews.API.Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public async void GetAllAsync()
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
        public async void GetByIdAsync()
        {
            // Arrange
            var productId = new Fixture().Create<int>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var product = await productService.GetByIdAsync(productId);

            // Assert
            productRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void GetDetailsByIdAsync()
        {
            // Arrange
            var productId = new Fixture().Create<int>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var product = await productService.GetDetailsByIdAsync(productId);

            // Assert
            productRepositoryMock.Verify(pr => pr.GetDetailsByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void GetReviewByIdAsync()
        {
            // Arrange
            var productId = new Fixture().Create<int>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var productReview = await productService.GetReviewByIdAsync(productId);

            // Assert
            productRepositoryMock.Verify(pr => pr.GetReviewByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void AddAsync()
        {
            // Arrange
            var addProductInputModel = new Fixture().Create<AddProductInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProduct = await productService.AddAsync(addProductInputModel);

            // Assert
            Assert.Equal(addedProduct.Title, addProductInputModel.Title);
            Assert.Equal(addedProduct.Description, addProductInputModel.Description);
            Assert.Equal(addedProduct.Price, addProductInputModel.Price);

            addedProduct.Title.ShouldBe(addProductInputModel.Title);
            addedProduct.Description.ShouldBe(addProductInputModel.Description);
            addedProduct.Price.ShouldBe(addProductInputModel.Price);

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async void UpdateAsync()
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
            Assert.Equal(updatedProduct.Title, addProductInputModel.Title);
            Assert.Equal(updatedProduct.Description, updateProductInputModel.Description);
            Assert.Equal(updatedProduct.Price, updateProductInputModel.Price);

            updatedProduct.Title.ShouldBe(addProductInputModel.Title);
            updatedProduct.Description.ShouldBe(updateProductInputModel.Description);
            updatedProduct.Price.ShouldBe(updateProductInputModel.Price);

            productRepositoryMock.Verify(pr => pr.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async void AddReviewAsync()
        {
            // Arrange
            var productId = new Fixture().Create<int>();
            var addProductReviewInputModel = new Fixture().Create<AddProductReviewInputModel>();

            var productRepositoryMock = new Mock<IProductRepository>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var addedProductReview = await productService.AddReviewAsync(productId, addProductReviewInputModel);

            // Assert
            Assert.Equal(addedProductReview.Rating, addProductReviewInputModel.Rating);
            Assert.Equal(addedProductReview.Author, addProductReviewInputModel.Author);
            Assert.Equal(addedProductReview.Comments, addProductReviewInputModel.Comments);

            addedProductReview.Rating.ShouldBe(addProductReviewInputModel.Rating);
            addedProductReview.Author.ShouldBe(addProductReviewInputModel.Author);
            addedProductReview.Comments.ShouldBe(addProductReviewInputModel.Comments);

            productRepositoryMock.Verify(pr => pr.AddReviewAsync(It.IsAny<ProductReview>()), Times.Once);
        }
    }
}