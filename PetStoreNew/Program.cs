using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetStore.Validators;

namespace PetStore
{
    public class petStore
    {
        public static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            var productLogic = services.GetService<IProductLogic>();

                //Method used to control the program
                string userPrompt = ProgramPrompts();

                while (userPrompt.ToLower() != "exit")
                {
                    if (userPrompt == "1")
                    {
                        Console.WriteLine("Is the product for a cat or a dog? ");
                        userPrompt = Console.ReadLine();

                        switch (userPrompt)
                        {
                            case "dog":
                                DogLeash.AddDogLeash((ProductLogic)productLogic);
                                break;

                            case "cat":
                                CatFood.AddCatFood((ProductLogic)productLogic);
                                break;

                            default:
                                break;
                        }
                    }

                    else if (userPrompt == "2")
                    {
                    Console.WriteLine("What is the name of the product you wish to look up?");
                    var lookupName = Console.ReadLine();
                    var productName = productLogic.GetProductByName<Product>(lookupName);
                    Console.WriteLine(JsonSerializer.Serialize(productName));
                    
                    }

                    else if (userPrompt == "3")
                    {
                        var Products = productLogic.GetOnlyInStockProducts();
                        foreach (string inStockProduct in Products)
                        {
                            Console.WriteLine(inStockProduct);
                        }
                    }

                    else if (userPrompt == "4")
                    {
                        Console.WriteLine($"The total price of everything in stock is ${productLogic.GetTotalPriceOfInventory()}.");
                      
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
            Console.WriteLine("Press 2 to look up a product.");
            Console.WriteLine("Press 3 to view all in stock products.");
            Console.WriteLine("Press 4 to see the total cost of every in stock product.");
            Console.WriteLine("Type 'exit' to quit. ");

            string userInput = Console.ReadLine();
            return userInput;
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }
    }
}