using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using XpoOrm.Models;

namespace XpoGraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //HACK https://documentation.devexpress.com/XPO/119377/Getting-Started/Getting-Started-with-NET-Core
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "myXpoApp.db"));
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);



            UnitOfWork UoW = new UnitOfWork();

            if (!UoW.Query<Customer>().Any())
            {
                Customer JoseManuel = new Customer(UoW) { Name = "Jose Manuel Ojeda" ,Address="Sain Petersburg"};
                Customer Oscar = new Customer(UoW) { Name = "Oscar", Address = "El Salvador" };
                Customer Pedro = new Customer(UoW) { Name = "Pedro" };
                UoW.CommitChanges();
            }

            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
