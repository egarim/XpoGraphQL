using GraphQL.Types;
using System;
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
                    var ProductInput = context.GetArgument<ProductInput>(STR_Product);
                    return ProductService.CreateAsync(ProductInput.Code, ProductInput.Name, ProductInput.Description);
                    //return new ProductInputType();
                }
            );

            //FieldAsync<OrderType>(
            //    "startOrder",
            //    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }),
            //    resolve: async context =>
            //    {
            //        var orderId = context.GetArgument<string>("orderId");
            //        return await context.TryAsyncResolve(
            //            async c => await orders.StartAsync(orderId));
            //    }
            //);
        }
    }
}
