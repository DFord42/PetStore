using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetStore
{
    public class petStore
    {
        public static void Main(string[] args)
        {
            var productLogic = new ProductLogic();

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
                    switch (userInput)
                    {
                        case "1":
                            {
                                Console.WriteLine("Is the product for a cat or a dog? ");
                                userInput = Console.ReadLine();

                                switch (userInput)
                                {
                                    case "dog":
                                        DogLeash.AddDogLeash(productLogic);
                                        break;

                                    case "cat":
                                        CatFood.AddCatFood(productLogic);
                                        break;

                                    default:
                                        break;
                                }
                                break;
                            }

                        case "2":
                            {
                                DictionaryLookup.Lookup(productLogic);
                                break;
                            }

                        case "3":
                            {
                                var Products = productLogic.GetOnlyInStockProducts();
                                foreach (string inStockProduct in Products)
                                {
                                    Console.WriteLine(inStockProduct);
                                }
                                break;
                            }

                        case "4":
                            {
                                Console.WriteLine($"The total price of everything in stock is ${productLogic.GetTotalPriceOfInventory()}.");
                                break;
                            }

                        case "exit ":
                            {
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("That answer is not valid. Please try again: ");
                                userInput = Console.ReadLine();
                                break;
                            }
                    }
                }

                Console.Write("Would you like to run the program again? Type \"Yes\" or \"No\": ");
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
    }
}