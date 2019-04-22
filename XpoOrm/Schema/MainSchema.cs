using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace XpoOrm.Schema
{
    public class MainSchema : GraphQL.Types.Schema
    {
        public MainSchema(Queries query, IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
        }
    }
}