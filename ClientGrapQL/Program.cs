using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Threading.Tasks;

namespace ClientGrapQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                Console.WriteLine("Press any key to start");
                Console.ReadKey();
                var heroRequest = new GraphQLRequest();
                heroRequest.Query = "{products{name description category { code name}}}";
                var graphQLClient = new GraphQLClient("https://localhost:44396/graphql");

                var graphQLResponse = await graphQLClient.PostAsync(heroRequest);
                Console.WriteLine(graphQLResponse.Data);

            }).Wait();

            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }
    }
}
