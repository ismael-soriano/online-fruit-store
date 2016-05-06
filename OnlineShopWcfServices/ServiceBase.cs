using Core;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopWcfServices
{
    public class ServiceBase
    {
        readonly IUnitOfWork _unitOfWork;
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            Check.NotNull(unitOfWork, "unitOfWork");
            _unitOfWork = unitOfWork;
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}