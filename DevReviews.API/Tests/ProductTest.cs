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
    public class ProductTest
    {
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
            Assert.Equal(addedProduct.Title, addProductInputModel.Title);
            Assert.Equal(addedProduct.Description, addProductInputModel.Description);
            Assert.Equal(addedProduct.Price, addProductInputModel.Price);

            addedProduct.Title.ShouldBe(addProductInputModel.Title);
            addedProduct.Description.ShouldBe(addProductInputModel.Description);
            addedProduct.Price.ShouldBe(addProductInputModel.Price);

            productRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}