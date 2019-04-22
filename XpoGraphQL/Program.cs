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

            if (!UoW.Query<Product>().Any())
            {

                Category BestFoodInTheWorld = new Category(UoW) { Code = "001", Name = "Best food in the world" };

                Category HealtyFood = new Category(UoW) { Code = "002", Name = "Healty Food" };

                Product Hamburger = new Product(UoW);
                Hamburger.Name = "Rocco's hamburger";
                Hamburger.Description = "is a cheeseburger with cheese inside the meat instead of on top, resulting in a melted core of cheese.";
                Hamburger.Code = "001";
                Hamburger.Category = BestFoodInTheWorld;
                Product Pizza = new Product(UoW);
                Pizza.Name = "Pizza";
                Pizza.Description = "Pizza Margherita is a typical Neapolitan pizza, made with San Marzano tomatoes, mozzarella fior di latte, fresh basil, salt and extra-virgin olive oil";
                Pizza.Code = "002";
                Pizza.Category = BestFoodInTheWorld;
                Product Tacos = new Product(UoW);
                Tacos.Name = "Tacos";
                Tacos.Description = "Carne Asada Tacos. Carne asada tacos are delicious, flank steak tacos with a few simple ingredients and tons of flavor";
                Tacos.Code = "003";
                Tacos.Category = BestFoodInTheWorld;


                Product Salad = new Product(UoW) { Name = "Salad", Description = "Just a salad", Code = "004", Category = HealtyFood };
            }
            UoW.CommitChanges();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
