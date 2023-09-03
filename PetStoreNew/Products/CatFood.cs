using System;
using PetStore;
using System.Text.Json.Serialization;

namespace PetStore
{
        // CatFood is a class that inherits the properties from Product as indicated by the :
        public class CatFood : Product
        {
            [JsonInclude]
            public bool KittenFood { get; set; }

        public override string ToString()
        {
            return ($"The cat food, {Name}, costs ${Price}, and has {Quantity} containers in stock."
                + $"\nSome words of wisdom about {Name} would have to be {Description}."
                + $"\nOh, and is it kitten food? The answer is {KittenFood}.");

        }

        public static void AddCatFood(ProductLogic productLogic)
        {
            CatFood catFood = new CatFood();

            Console.WriteLine("You will be adding some cat food.");
          
            Console.WriteLine("What is the name of this cat food? ");
            catFood.Name = Console.ReadLine();

            Console.WriteLine($"How much money will {catFood.Name} cost? ");

            bool test = decimal.TryParse(Console.ReadLine(), out decimal price);
            catFood.Price = price;

            Console.WriteLine($"How many containers of {catFood.Name} are there? ");
            bool quantity = int.TryParse(Console.ReadLine(), out int amount);
            catFood.Quantity = amount;


            Console.WriteLine($"Please enter a short description of {catFood.Name}: ");
            catFood.Description = Console.ReadLine();

            /* Console.WriteLine($"Is {catFood.Name} dry food? ");
             var answer = Console.ReadLine();

             if (answer.ToLower() == "yes")
             {
                 Console.WriteLine($"How many pounds does {catFood.Name} weigh? ");
                 //Tests if the response is a double. If so, it is assigned to catFood's WeightPounds
                 test = double.TryParse(Console.ReadLine(), out double weight);
                 CatFood dryCatFood.WeightPounds = weight;
             }
             else
             {
                 Console.WriteLine("Okay. I was just checking.");
             } */

            Console.WriteLine("Is this food for a kitten? Yes or no: ");
            string check = Console.ReadLine();

            if (check.ToLower() == "yes")
            {
                catFood.KittenFood = true;
            }
            else if (check.ToLower() == "no")
            {
                catFood.KittenFood = false;
            }
            else
            {
                Console.WriteLine("The label is not clear, so it is safe to assume this should not be fed to a kitten.");
                catFood.KittenFood = false;
            }


            productLogic.AddProduct(catFood);
            Console.WriteLine($"That sounds delicious! Those cats will certainly love {catFood.Name}.");
        }
    }
    
}

