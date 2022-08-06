using OnionArch.Data.Entities;
using OnionArch.Repository.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnionArch.Repository.SeedData
{
    public class ShopSeed
    {
        public static async Task SeedAsync(ShopContext context)
        {
            try
            {

                 if (!context.ProductTypes.Any())
                {

                    var productsType = 
                        File.ReadAllText("../OnionArch.Repository/SeedData/ProductType.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productsType); 

                     foreach (var type in types)
                    {
                        context.ProductTypes.Add(new ProductType() { Name=type.Name});
                    }
                    await context.SaveChangesAsync();


                }


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../OnionArch.Repository/SeedData/Products.json");

                    
                    var productsSeeders = JsonSerializer.Deserialize<List<ProductSeeder>>(productsData);

                    foreach (var productSeeder in productsSeeders)
                    {
                        Product product= new Product();
                        product.Name = productSeeder.Name;
                        product.Description = productSeeder.Description;
                        product.Price = productSeeder.Price;
                        product.PictureUrl = productSeeder.PictureUrl;
                        product.ProductTypeId= productSeeder.ProductTypeId;
                        product.Id = Guid.NewGuid();
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
