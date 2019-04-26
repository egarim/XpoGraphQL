using GraphQL.Conversion;
using GraphQL.Introspection;
using GraphQL.Types;
using System;
using System.Linq;
using XpoOrm.Services;

namespace XpoOrm.Schema
{
    public class Mutations : ObjectGraphType<object>
    {
        //TODO find a way to change this https://stackoverflow.com/questions/55853230/how-to-use-pascal-casing-instead-of-camel-casing-in-graphql-dotnet
        //the names of the fields in graphical are always camel casing
        const string STR_Product = "product";
        public Mutations(IProductService ProductService)
        {
            Name = "Mutation";
            Field<ProductType>(
                "CreateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = STR_Product }),
                resolve: context =>
                {
                    //here we can define an input type or just use dynamic as shown below
                    var ProductInput = context.GetArgument<ProductInput>(STR_Product);
                    
                    //reading the parameter and set it to a dynamic type
                    //var ProductInputDynamic = context.GetArgument<dynamic>(STR_Product);

                    return ProductService.CreateAsync(ProductInput.Code, ProductInput.Name, ProductInput.Description);
                    
                }
            );

            FieldAsync<ProductType>(
                "discontinueProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "oid" }),
                resolve: async context =>
                {
                    var oid = context.GetArgument<int>("oid");
                    return await context.TryAsyncResolve(
                        async c => await ProductService.DiscontinueProductAsync(oid));
                }
            );
        }
    }
}
