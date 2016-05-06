using Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        readonly IDbContext _context;
        public RepositoryBase(IDbContext context)
        {
            Check.NotNull(context, "context");
            _context = context;
        }

        public DbSet<T> Entity
        {
            get
            {
                return _context.GetSet<T>();
            }
        }
    }
}
