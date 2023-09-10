using System;
using System.Text.Json.Serialization;
namespace PetStore
{
	public class DryCatFood : CatFood
	{
			[JsonInclude]
            public double WeightPounds { get; set; }

        public override string ToString()
        {
            return ($"The dry cat food, {Name}, costs ${Price}, and has {Quantity} containers in stock. It also weighs {WeightPounds} pounds."
                + $"\nSome words of wisdom about {Name} would have to be {Description}."
                + $"\nOh, and is it kitten food? The answer is {KittenFood}.");

        }

        public static void AddDryCatFood(ProductLogic productLogic)
        {
            DryCatFood dryCatFood = new DryCatFood();

            Console.WriteLine("You will be adding some cat food.");

            Console.WriteLine("What is the name of this cat food? ");
            dryCatFood.Name = Console.ReadLine();

            Console.WriteLine($"How much money will {dryCatFood.Name} cost? ");

            bool test = decimal.TryParse(Console.ReadLine(), out decimal price);
            dryCatFood.Price = price;

            Console.WriteLine($"How many containers of {dryCatFood.Name} are there? ");
            bool quantity = int.TryParse(Console.ReadLine(), out int amount);
            dryCatFood.Quantity = amount;


            Console.WriteLine($"Please enter a short description of {dryCatFood.Name}: ");
            dryCatFood.Description = Console.ReadLine();


            Console.WriteLine("Is this food for a kitten? Yes or no: ");
            string check = Console.ReadLine();

            if (check.ToLower() == "yes")
            {
                dryCatFood.KittenFood = true;
            }
            else if (check.ToLower() == "no")
            {
                dryCatFood.KittenFood = false;
            }
            else
            {
                Console.WriteLine("The label is not clear, so it is safe to assume this should not be fed to a kitten.");
                dryCatFood.KittenFood = false;
            }

            Console.WriteLine($"How much does {dryCatFood.Name} weigh?");
            test = double.TryParse(Console.ReadLine(), out double weight);
            dryCatFood.WeightPounds = weight;


            productLogic.AddProduct(dryCatFood);
            Console.WriteLine($"That sounds delicious! Those cats will certainly love {dryCatFood.Name}.");
        }
    }
}

