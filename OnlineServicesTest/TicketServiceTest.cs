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
        private const int FIRST = 0;
        private const int DETAILS_COUNT = 1;
        private const decimal DETAIL_QUANTITY = 4;
        private const decimal DETAIL_PRICE = 14;
        private const string PRODUCT_NAME = "manzana";
        private const decimal PRODUCT_PRICE = 3.5m;
        private MockFactory _factory = new MockFactory();
        TicketDetail detail;
        Ticket ticket;
        DateTime date;
        
        [TestInitialize]
        public void Initialize()
        {
            date = DateTime.Now;
            detail = new TicketDetail() { Product = new Product() { Name = PRODUCT_NAME, Price = PRODUCT_PRICE }, Quantity = DETAIL_QUANTITY, Price = DETAIL_PRICE };
            ticket = new Ticket() { Id = 1, Date = date, Details = new List<TicketDetail>() { detail } };
        }

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

            var tickets = new HashSet<Ticket>() { ticket };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(tickets);

            // Act
            var result = new List<Ticket>(service.GetAll());

            // Assert
            Assert.AreEqual(DETAILS_COUNT, result.Count);
            Assert.AreEqual(date, result[FIRST].Date);
        }

        [TestMethod]
        public void ShouldGetATicket()
        {
            // Arrange
            var repository = _factory.CreateMock<IRepositoryTicket>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var service = new TicketService(repository.MockObject, unitOfWork.MockObject);

            repository.Expects.One.MethodWith(c => c.Get(1)).WillReturn(ticket);

            // Act
            var result = service.Get(1);
            var resultDetails = new List<TicketDetail>(result.Details);

            // Assert
            Assert.AreEqual(DETAILS_COUNT, resultDetails.Count);
            Assert.AreEqual(date, result.Date);
        }
    }
}
