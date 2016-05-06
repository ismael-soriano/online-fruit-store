using Domain.Products;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopWcfServices.Configurations
{
    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            IList<Product> defaultProducts = new List<Product>();

            defaultProducts.Add(new Product() { Id = 1, Name = "Manzana", Price = 1 });
            defaultProducts.Add(new Product() { Id = 2, Name = "Pera", Price = 3.45m });
            defaultProducts.Add(new Product() { Id = 3, Name = "Naranja", Price = 1.32m });

            foreach (Product product in defaultProducts)
                context.Products.Add(product);

            base.Seed(context);
        }
    }
}