using Domain.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RepositoryTicket : RepositoryBase<Ticket>, IRepositoryTicket
    {
        public RepositoryTicket(IDbContext context) : base(context)
        {

        }

        public IEnumerable<Ticket> GetAll()
        {
            return Entity.Select(c => c).ToList();
        }

        public Ticket Get(int id)
        {
            return Entity.Find(id);
        }

        public void Update(Ticket ticket)
        {
            Modify(ticket);
        }
    }
}
