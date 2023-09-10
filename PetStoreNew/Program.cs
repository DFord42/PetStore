using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PetStore
{
    public class petStore
    {
        public static void Main(string[] args)
        {

            var services = CreateServiceCollection();

            var productLogic = services.GetService<IProductLogic>();
            

            //Declaring variable used to accept a user's response

            string runProgram = "yes";

            while (runProgram.ToLower() == "yes")
            { 

            Console.WriteLine("Press 1 to enter a product.");
            Console.WriteLine("Press 2 to look up a product.");
            Console.WriteLine("Press 3 to view all in stock products.");
            Console.WriteLine("Press 4 to see the total cost of every in stock product.");
            Console.WriteLine("Type 'exit' to quit. ");

            string userInput = Console.ReadLine();

                while (userInput.ToLower() != "exit")
                {
                    if (userInput == "1")
                    {
                        Console.WriteLine("Is the product for a cat or a dog? ");
                        userInput = Console.ReadLine();

                        switch (userInput)
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
                        break;
                    }

                    else if (userInput == "2")
                    {
                        DictionaryLookup.Lookup((ProductLogic)productLogic);
                        break;
                    }

                    else if (userInput == "3")
                    {
                        var Products = productLogic.GetOnlyInStockProducts();
                        foreach (string inStockProduct in Products)
                        {
                            Console.WriteLine(inStockProduct);
                        }
                        break;
                    }

                     else if (userInput == "4")
                    {
                        Console.WriteLine($"The total price of everything in stock is ${productLogic.GetTotalPriceOfInventory()}.");
                        break;
                    }

                    else if (userInput.ToLower() == "exit ")
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("That answer is not valid.");
                        break;
                    }
                }

                Console.Write("Would you like to continue using the program? Type \"Yes\" or \"No\": ");
                runProgram = Console.ReadLine();
                while (runProgram.ToLower() != "yes" && runProgram.ToLower() != "no")
                {
                    Console.WriteLine("What was that? Did you say \"Yes\" or \"No\"? ");
                    runProgram = Console.ReadLine();
                }
            }
            Console.WriteLine("Thank you for visiting your local pet store!");
            Console.ReadKey();
        }
        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }
    }
}