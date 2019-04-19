using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpoOrm.Models;

namespace XpoOrm.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomerByOid(int Oid)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Query<Customer>().Where(c => c.Oid == Oid).FirstOrDefault();

            }
        }

        public Task<Customer> GetCustomerByOidAsync(int Oid)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return Task.FromResult<Customer>(uow.Query<Customer>().Where(c => c.Oid == Oid).FirstOrDefault());

            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Query<Customer>().ToList();

            }
        }
    }
}
