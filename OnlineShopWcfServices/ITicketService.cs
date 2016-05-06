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
        [WebInvoke(Method = "POST", UriTemplate = "AddTicket", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        void Add(Ticket ticket);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateTicket", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        void Update(Ticket ticket);

        [OperationContract]
        [WebGet(UriTemplate = "Ticket?id={id}", ResponseFormat = WebMessageFormat.Json)]
        Ticket Get(int id);

        [OperationContract]
        [WebGet(UriTemplate = "Tickets", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Ticket> GetAll();
    }
}
