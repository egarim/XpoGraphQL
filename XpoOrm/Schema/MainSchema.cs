using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using static XpoOrm.Schema.ProductType;

namespace XpoOrm.Schema
{
    public class MainSchema : GraphQL.Types.Schema
    {
        public MainSchema(Queries query, IDependencyResolver dependencyResolver, Mutations mutations) : base(dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
            Mutation = mutations;
            //this.FieldNameConverter = new CamelCaseFieldNameConverter();
         
        }
    }
}