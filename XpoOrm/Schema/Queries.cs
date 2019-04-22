using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using XpoOrm.Models;
using XpoOrm.Services;

namespace XpoOrm.Schema
{
    public class Queries : ObjectGraphType<Object>
    {
        public Queries(IProductService IProductService, ICategoryService ICategoryService)
        {
            this.Name = "Queries";
            Field<ListGraphType<ProductType>>("Products", resolve: context => IProductService.GetProducts());

            Field<ListGraphType<CategoryType>>("Categories", resolve: context => ICategoryService.GetCategories());
        }
    }
}