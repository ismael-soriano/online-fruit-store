using Core;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        public RepositoryProduct(ShopDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Product> GetAll()
        {
            return Entity.Select(c => c).ToList();
        }
    }
}
