using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace XpoOrm.Schema
{
    public class ProductSchema:GraphQL.Types.Schema
    {
       
        public ProductSchema(ProductsQuery query,IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
        }
    }
}
