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
                new TicketDetail() {Id = 1, Product = new Product() {Name = "manzana", Price = 3.5m}, Quantity = 4}
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
    }
}
