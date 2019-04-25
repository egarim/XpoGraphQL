using GraphQL.Types;
using System;

namespace XpoOrm.Schema
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";

            Field<NonNullGraphType<StringGraphType>>("Code");
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<StringGraphType>>("Description");

        }
    }
}
