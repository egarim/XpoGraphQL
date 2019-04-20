using GraphQL.Types;
using System;
using XpoOrm.Services;

namespace XpoOrm.Schema
{
    public class CategoryQuery : ObjectGraphType<Object>
    {
        public CategoryQuery(ICategoryService ICategoryService)
        {
            this.Name = "CategoryQuery";
            Field<ListGraphType<CategoryType>>("Categories", resolve: context => ICategoryService.GetCategories());
        }
    }
}
