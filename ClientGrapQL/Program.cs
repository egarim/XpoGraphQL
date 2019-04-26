using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ClientGrapQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                try
                {
                    var graphQLClient = new GraphQLClient("https://localhost:44396/graphql");
                    await ExecuteProductQuery(graphQLClient);

                    await ExecuteProductMutation(graphQLClient);
                }
                catch (Exception exception)
                {

                    Debug.WriteLine(string.Format("{0}:{1}", "exception.Message", exception.Message));
                    if (exception.InnerException != null)
                    {
                        Debug.WriteLine(string.Format("{0}:{1}", "exception.InnerException.Message", exception.InnerException.Message));

                    }
                    Debug.WriteLine(string.Format("{0}:{1}", " exception.StackTrace", exception.StackTrace));
                }



            }).Wait();

            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }

        private static async Task ExecuteProductQuery(GraphQLClient graphQLClient)
        {
            Console.WriteLine("Press any key to execute product query");
            Console.ReadKey();
            var ProductsQueryRequest = new GraphQLRequest();
            ProductsQueryRequest.Query = "{products{name description category { code name}}}";
            var graphQLResponse = await graphQLClient.PostAsync(ProductsQueryRequest);
            Console.WriteLine(graphQLResponse.Data);
        }

        private static async Task ExecuteProductMutation(GraphQLClient graphQLClient)
        {
            Console.WriteLine("Press any key to execute mutation");
            Console.ReadKey();
            var ProductsMutationRequest = new GraphQLRequest();
            //for the mutation is important that the mutation name "createProduct" is in camel casing,
            //even when is defined on the server as "CreateProduct", the graphql specification requires it to be camel casing
            //in the query below "CreateProduct" is the operation name
            ProductsMutationRequest.Query =
            @"mutation CreateProduct($product:ProductInput!)
                    {
                      createProduct(product:$product)
                      {
                        oid
                        description
                      }
                    }";
            //Not necessary it the server can figure it out
            ProductsMutationRequest.OperationName = "CreateProduct";
            ProductsMutationRequest.Variables = new
            {
                //in the mutation the variable product is defined with lower case, because of the resolver we can use any case
                Product = new
                {
                    code = "Test",
                    name = "Test product",
                    description = "test description"
                }

            };

            var MutationResponse = await graphQLClient.PostAsync(ProductsMutationRequest);
            
            //you can get the data from the dynamic object on as shown below
            var Oid= MutationResponse.Data.createProduct.oid;


            Console.WriteLine(MutationResponse.Data);
        }
    }
}
