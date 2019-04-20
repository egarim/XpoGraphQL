using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using XpoOrm.Models;
using XpoOrm.Services;

namespace XpoOrm.Schema
{
    public class ProductType:ObjectGraphType<Product>
    {
        public ProductType(ICategoryService CategoryService)
        {
            Field(c => c.Oid);
            Field(c => c.Code);
            Field(c => c.Name);
            Field(c => c.Description,true);
            Field<CategoryType>("Category",
                 resolve: context => CategoryService.GetCategoryByOidAsync(context.Source.Category.Oid));


        }
    }
}
