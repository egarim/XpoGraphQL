﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using XpoOrm.Schema;
using XpoOrm.Services;

namespace XpoGraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<CustomerType>();
            services.AddSingleton<CustomerQuery>();
            services.AddSingleton<CustomerSchema>();

            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
              .AddWebSockets() // Add required services for web socket support
              .AddDataLoader(); // Add required services for DataLoader support
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseWebSockets();

            //app.UseGraphQLWebSockets<CustomerType>();
            //app.UseGraphQLHttp<CustomerSchema>();

           

            // use websocket middleware for ChatSchema at path /graphql
            app.UseGraphQLWebSockets<CustomerSchema>("/graphql");



            // use graphiQL middleware at default url /graphiql
            app.UseGraphQL<CustomerSchema>();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}