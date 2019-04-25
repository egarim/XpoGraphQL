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

            //this is the common design pattern to resolve related object using the services
            Field<CategoryType>("Category",
                 resolve: context => CategoryService.GetCategoryByOidAsync(context.Source.Category.Oid));

            //this is the second approach,the XPO approach, since the product model is already loaded and XPO provides lazy loading we can skip
            //the injection of the service and just load the category from the context which is basically the instance in memory of the Product model

            //Field<CategoryType>("Category",
            //     resolve: context => context.Source.Category);


        }
     
    }
}
