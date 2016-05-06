using Domain.Products;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core;

namespace OnlineShopWcfServices
{
    public class ProductService : ServiceBase, IProductService
    {
        readonly IRepositoryProduct _repository;
        public ProductService(IRepositoryProduct repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Check.NotNull(repository, "repository");
            _repository = repository;
        }

        public IEnumerable<Product> GetAll()
        {
           return _repository.GetAll();
        }
    }
}
