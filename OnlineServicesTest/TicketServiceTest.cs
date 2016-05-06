using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Products;
using Infrastructure;
using OnlineShopWcfServices;
using System.Collections.Generic;
using Domain.Tickets;
using NMock;

namespace OnlineServicesTest
{
    [TestClass]
    public class TicketServiceTest
    {
        private const int DETAILS_COUNT = 1;
        private const decimal DETAIL_QUANTITY = 4;
        private const decimal DETAIL_PRICE = 14;
        private const string PRODUCT_NAME = "manzana";
        private const decimal PRODUCT_PRICE = 3.5m;
        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void ShouldGetAllTickets()
        {
            // Arrange
            var repository = _factory.CreateMock<IRepositoryTicket>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var service = new TicketService(repository.MockObject, unitOfWork.MockObject);

            var date = DateTime.Now;
            var details = new HashSet<TicketDetail>() {
                new TicketDetail() { Product = new Product() {Name = PRODUCT_NAME, Price = PRODUCT_PRICE}, Quantity = DETAIL_QUANTITY, Price = DETAIL_PRICE }
            };

            var tickets = new HashSet<Ticket>() {
                new Ticket() {Id= 1, Date = date, Details = details}
            };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(tickets);
            //unitOfWork.Expects.One.Method(c => c.Dispose());

            // Act
            var result = new List<Ticket>(service.GetAll());

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(date, result[0].Date);
        }

        [TestMethod]
        public void ShouldGetATicket()
        {
            // Arrange
            var repository = _factory.CreateMock<IRepositoryTicket>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var service = new TicketService(repository.MockObject, unitOfWork.MockObject);

            var date = DateTime.Now;
            var details = new HashSet<TicketDetail>() {
                new TicketDetail() {Id = 1, Product = new Product() {Name = "manzana", Price = 3.5m}, Quantity = 4}
            };

            var ticket = new Ticket() { Id = 1, Date = date, Details = details };

            repository.Expects.One.MethodWith(c => c.Get(1)).WillReturn(ticket);
            //unitOfWork.Expects.One.Method(c => c.Dispose());

            // Act
            var result = service.Get(1);
            var resultDetails = new List<TicketDetail>(result.Details);

            // Assert
            Assert.AreEqual(DETAILS_COUNT, resultDetails.Count);
            Assert.AreEqual(date, result.Date);
        }
    }
}
