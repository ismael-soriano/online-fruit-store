using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tickets
{
    public interface IRepositoryTicket
    {
        Ticket Add(Ticket ticket);
        IEnumerable<Ticket> GetAll();
        Ticket Get(int id);
        void Update(Ticket ticket);
    }
}
