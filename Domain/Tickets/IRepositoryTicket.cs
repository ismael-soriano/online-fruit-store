using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tickets
{
    public interface IRepositoryTicket
    {
        IEnumerable<Ticket> GetAll();
        Ticket Get(int id);
        void Update(Ticket ticket);
    }
}
