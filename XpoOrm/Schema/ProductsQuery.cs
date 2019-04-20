using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using XpoOrm.Models;
using XpoOrm.Services;

namespace XpoOrm.Schema
{
    public class ProductsQuery: ObjectGraphType<Object>
    {
        public ProductsQuery(IProductService IProductService,ICategoryService ICategoryService)
        {
            this.Name = "Queries";
            Field<ListGraphType<ProductType>>("Products", resolve: context => IProductService.GetProducts());

            Field<ListGraphType<CategoryType>>("CategoriesList", resolve: context => ICategoryService.GetCategories());
        }
    }
}
