using Domain.Products;
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
    public interface IProductService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Products", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Product> GetAll();
    }
}
