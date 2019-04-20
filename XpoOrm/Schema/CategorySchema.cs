using GraphQL;
using System;

namespace XpoOrm.Schema
{
    public class CategorySchema : GraphQL.Types.Schema
    {

        public CategorySchema(CategoryQuery query, IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
        }
    }
}
