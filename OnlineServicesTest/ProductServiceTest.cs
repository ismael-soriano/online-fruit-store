using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Domain.Products;
using Infrastructure;
using System.Collections.Generic;
using OnlineShopWcfServices;

namespace OnlineServicesTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void ShouldGetAllProducts()
        {
            // Arrange
            var repository = _factory.CreateMock<IRepositoryProduct>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var service = new ProductService(repository.MockObject, unitOfWork.MockObject);

            var products = new HashSet<Product>() {
                new Product() {Id= 1, Name = "pera", Price = 3}
            };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(products);
            //unitOfWork.Expects.One.Method(c => c.Dispose());

            // Act
            var result = new List<Product> (service.GetAll());

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("pera", result[0].Name);
        }
    }
}
