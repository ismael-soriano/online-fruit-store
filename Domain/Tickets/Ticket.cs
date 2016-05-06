using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tickets
{
    public class Ticket : EntityBase
    {
        public DateTime Date { get; set; }
        public IEnumerable<TicketDetail> Details { get; set; }
        
        public Ticket()
        {
            Details = new HashSet<TicketDetail>();
        }

    }
}
