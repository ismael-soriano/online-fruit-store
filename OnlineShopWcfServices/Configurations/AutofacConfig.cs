﻿using Autofac;
using Domain.Products;
using Domain.Tickets;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopWcfServices.Configurations
{
    public class AutofacConfig
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            // Register your service implementations.
            builder.RegisterType<ShopDbContext>().As<IDbContext>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<RepositoryProduct>().As<IRepositoryProduct>();
            builder.RegisterType<RepositoryTicket>().As<IRepositoryTicket>();
            builder.RegisterType<OnlineShopWcfServices.ProductService>().As<IProductService>();
            builder.RegisterType<OnlineShopWcfServices.TicketService>().As<ITicketService>();

            // Set the dependency resolver.
            return builder.Build();
        }
    }
}