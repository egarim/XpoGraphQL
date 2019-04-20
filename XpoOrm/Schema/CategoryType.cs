using GraphQL.Types;
using System;
using XpoOrm.Models;

namespace XpoOrm.Schema
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(c => c.Oid);
            Field(c => c.Name);
            Field(c => c.Code);


        }
    }
}
