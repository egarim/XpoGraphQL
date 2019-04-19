using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace XpoOrm.Schema
{
    public class CustomerSchema:GraphQL.Types.Schema
    {
        public CustomerSchema()
        {

        }

        [Obsolete("The Func<Type, IGraphType> constructor has been deprecated in favor of using IDependencyResolver.  Use FuncDependencyResolver to continue using a Func.  This constructor will be removed in a future version.")]
        public CustomerSchema(Func<Type, IGraphType> resolveType) : base(resolveType)
        {

        }

        public CustomerSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
           
        }
        public CustomerSchema(CustomerQuery query,IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
        }
    }
}
