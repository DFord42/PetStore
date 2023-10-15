using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetStore.Data;

namespace PetStore
{
    public class petStore
    {
        public static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            var productLogic = services.GetService<IProductLogic>();
            var productRepository = services.GetService<IProductRepository>();

                //Method used to control the program
                string userPrompt = ProgramPrompts();

                while (userPrompt.ToLower() != "exit")
                {
                    if (userPrompt == "1")
                    {
                    Console.WriteLine("Please enter a product in Json format.");
                    var product = JsonSerializer.Deserialize<ProductEntity>(Console.ReadLine());
                    productRepository.AddNewProduct(product);
                    }

                    else if (userPrompt == "2")
                    {
                    Console.WriteLine("What is the ID of the product you wish to look up?");
                    var test = int.TryParse(Console.ReadLine(), out int lookupId);
                    var productName = productLogic.GetProductById(lookupId);
                    Console.WriteLine(JsonSerializer.Serialize(productName));
                    
                    }

                    else if (userPrompt.ToLower() == "exit ")
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("That answer is not valid.");
                    }
                

                userPrompt = ProgramPrompts();
            }
            Console.WriteLine("Thank you for visiting your local pet store!");
            Console.ReadKey();
        }

        private static string ProgramPrompts()
        {
            Console.WriteLine("Press 1 to enter a product.");
            Console.WriteLine("Press 2 to look up a product by its ID number.");
            Console.WriteLine("Type 'exit' to quit. ");

            string userInput = Console.ReadLine();
            return userInput;
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .AddTransient<IProductRepository, ProductRepository>()
                .BuildServiceProvider();
        }
    }
}