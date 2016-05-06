using Core;
using Domain.Tickets;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnlineShopWcfServices
{
    public class TicketService : ServiceBase, ITicketService
    {
        readonly IRepositoryTicket _repository;
        public TicketService(IRepositoryTicket repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Check.NotNull(repository, "repository");
            _repository = repository;
        }
        public IEnumerable<Domain.Tickets.Ticket> GetAll()
        {
            return _repository.GetAll();
        }

        public Domain.Tickets.Ticket Get(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Domain.Tickets.Ticket ticket)
        {
            _repository.Update(ticket);
        }
    }
}
