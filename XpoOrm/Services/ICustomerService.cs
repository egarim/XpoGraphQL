using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XpoOrm.Models;

namespace XpoOrm.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerByOid(int Oid);
        Task<Customer> GetCustomerByOidAsync(int Oid);

        IEnumerable<Customer> GetCustomers();
    }
}
