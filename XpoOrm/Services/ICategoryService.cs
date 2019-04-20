using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XpoOrm.Models;

namespace XpoOrm.Services
{
    public interface ICategoryService
    {
        Category GetCategoryByOid(int Oid);
        Task<Category> GetCategoryByOidAsync(int Oid);

        IEnumerable<Category> GetCategories();
    }
}
