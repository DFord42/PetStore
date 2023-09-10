using PetStore;
using System.Text.Json;
namespace PetStore
{
    public class DictionaryLookup
	{
        public static void Lookup(ProductLogic productLogic)
        {
            Console.WriteLine("Does the product you are searching for belong to a dog or a cat?");
            var lookupType = Console.ReadLine();

            while (lookupType != "invalid")
            {
                if (lookupType.ToLower() == "dog")
                {
                    DogLeashLookup(productLogic);
                    break;
                }
                else if (lookupType.ToLower() == "cat")
                {

                    CatFoodLookup(productLogic);
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Please enter 'dog' or 'cat'");
                    lookupType = "invalid";
                }
            }
        }

		public static void CatFoodLookup(ProductLogic productLogic)
		{
            
            Console.WriteLine("What is the name of the cat food?");
            string name = Console.ReadLine();

            JsonSerializer.Serialize(productLogic.GetCatFoodByName(name));

            if (productLogic.GetCatFoodByName(name) == null)
            {
                Console.WriteLine("That product cannot be found.");
            }
            else
            {
                Console.WriteLine(productLogic.GetCatFoodByName(name).ToString());
            }
        }

        public static void DogLeashLookup(ProductLogic productLogic)
        {
            Console.WriteLine("What is the name of the dog leash?");
            string name = Console.ReadLine();

            JsonSerializer.Serialize(productLogic.GetDogLeashByName(name));

            if (productLogic.GetDogLeashByName(name) == null)
            {
                Console.WriteLine("That product cannot be found.");
            }
            else
            {
                Console.WriteLine(productLogic.GetDogLeashByName(name).ToString());
            }
        }

        public static void DryCatFoodLookup(ProductLogic productLogic)
        {
            Console.WriteLine("What is the name of the dry cat food?");
            string name = Console.ReadLine();

            JsonSerializer.Serialize(productLogic.GetDryCatFoodByName(name));

            if (productLogic.GetDryCatFoodByName(name) == null)
            {
                Console.WriteLine("That product cannot be found.");
            }
            else
            {
                Console.WriteLine(productLogic.GetCatFoodByName(name).ToString());
            }
        }
           
	}
}

