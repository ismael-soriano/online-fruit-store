using Domain.Products;
using Domain.Tickets;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ShopDbContext : DbContext, IDbContext, IUnitOfWork
    {
        public DbSet<Product> Products {get; set;} // Needed for database seed purposes.
        public DbSet<Ticket> Tickets { get; set; }

        public ShopDbContext()
            : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }
    }
}
