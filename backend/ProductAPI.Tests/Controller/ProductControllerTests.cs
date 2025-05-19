using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAPI.Controllers;
using ProductAPI.models;
using ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductAPI.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _controller = new ProductController(_mockProductRepository.Object);
        }

        //Test 1: Get All Products Test
        [Fact]
        public async Task GetAllProducts_ReturnsOkResult_WithProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Test product 1", Description = "Description 1", Price = 699 },
                new Product { Id = 2, Name = "Test Product 2", Description = "Description 2", Price = 5000 }
            };

            _mockProductRepository.Setup(repo => repo.GetAllProductsAsync())
                .ReturnsAsync(products);

            //Act
            var result = await _controller.GetAllProducts();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);


            Assert.NotNull(returnedProducts);
            Assert.Equal(2, returnedProducts.Count());
        }

        //Test 2: 
        [Fact]
        public async Task GetProductById_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var productId = 1;
            var product = new Product { Id = productId, Name = "Test Product", Description = "Desc", Price = 50 };

            _mockProductRepository.Setup(repo => repo.GetProductByIdAsync(productId))
                .ReturnsAsync(product);

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);

            
            Assert.NotNull(returnedProduct);
            Assert.Equal(productId, returnedProduct.Id);
        }
    }
}
