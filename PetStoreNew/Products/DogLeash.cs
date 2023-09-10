using System;
using System.Text.Json.Serialization;

namespace PetStore
{

    
        //This declares the class DogLeash that inherits properties of Product
        public class DogLeash : Product
        {

            [JsonInclude]
            public int LengthInches { get; set; }
            [JsonInclude]
            public string Material { get; set; }
        
        public override string ToString()
        {
            return ($"The dog leash, {Name}, costs ${Price}, and has {Quantity} leashes in stock."
                + $"\nSome words of wisdom about {Name} would have to be {Description}."
                + $"\nThe wonderful product, {Name}, is {LengthInches} inches long and made out of {Material}.");

        }

        public static void AddDogLeash(ProductLogic productLogic)
        {
            DogLeash dogLeash = new DogLeash();

            Console.WriteLine("You will be adding a leash for a dog.");

            Console.WriteLine("What is the name of this leash? ");
            dogLeash.Name = Console.ReadLine();

            Console.WriteLine($"How much money will {dogLeash.Name} cost? ");
            bool test = decimal.TryParse(Console.ReadLine(), out decimal price);
            dogLeash.Price = price;

            Console.WriteLine("How many leashes are there? ");
            test = int.TryParse(Console.ReadLine(), out int quantity);
            dogLeash.Quantity = quantity;

            Console.WriteLine($"Please enter a short description about {dogLeash.Name}: ");
            dogLeash.Description = Console.ReadLine();

            Console.WriteLine($"How many inches long is {dogLeash.Name}? ");
            test = int.TryParse(Console.ReadLine(), out int length);
            dogLeash.LengthInches = length;

            Console.WriteLine("What is the leash made of? ");
            dogLeash.Material = Console.ReadLine();

            

            productLogic.AddProduct(dogLeash);

            Console.WriteLine($"Oh boy! Those pups will really enjoy walking with {dogLeash.Name}!");


        }
    }
}

