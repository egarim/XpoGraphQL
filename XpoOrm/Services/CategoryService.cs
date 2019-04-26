using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XpoOrm.Models;

namespace XpoOrm.Services
{
    public class CategoryService : ICategoryService
    {

        public CategoryService()
        {

        }

        public IEnumerable<Category> GetCategories()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Query<Category>().ToList();

            }
        }

        public Category GetCategoryByOid(int Oid)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Query<Category>().Where(c => c.Oid == Oid).FirstOrDefault();

            }
        }

        public Task<Category> GetCategoryByOidAsync(int? Oid)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return Task.FromResult<Category>(uow.Query<Category>().Where(c => c.Oid == Oid).FirstOrDefault());

            }
        }
    }
}
