using Core;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tickets
{
    public class TicketDetail : EntityBase
    {
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}
