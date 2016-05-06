using Domain.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OnlineShopWcfServices
{
    [ServiceContract]
    public interface ITicketService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Tickets", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Ticket> GetAll();

        [OperationContract]
        Ticket Get(int id);

        [OperationContract]
        void Update(Ticket ticket);
    }
}
