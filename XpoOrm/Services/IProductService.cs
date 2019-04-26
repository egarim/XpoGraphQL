using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XpoOrm.Models;

namespace XpoOrm.Services
{

    public interface IProductService
    {
        Product GetProductByOid(int Oid);
        Task<Product> DiscontinueProductAsync(int Oid);
        Task<Product> GetProductByOidAsync(int Oid);

        IEnumerable<Product> GetProducts();
        Task<Product> CreateAsync(string Code, string Name, string Description);
    }
}
