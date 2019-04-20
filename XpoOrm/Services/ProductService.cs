using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpoOrm.Models;

namespace XpoOrm.Services
{
    public class ProductService : IProductService
    {
        public Product GetProductByOid(int Oid)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Query<Product>().Where(c => c.Oid == Oid).FirstOrDefault();

            }
        }

        public Task<Product> GetProductByOidAsync(int Oid)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return Task.FromResult<Product>(uow.Query<Product>().Where(c => c.Oid == Oid).FirstOrDefault());

            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Query<Product>().ToList();

            }
        }
    }
}
