using System;
namespace PetStore
{
	public class ProductLogic : IProductLogic

	{
		private List<Product> _products;

		public ProductLogic()

		{

			_products = new List<Product>()
			{
				new DogLeash
				{
					Name = "Walky Buddy",
					Price = 20,
					Quantity = 3,
					LengthInches = 24,
					Material = "Two bagels",
					Description = "Take your fluffy buddy on an adventure with two large bagels that were dismantled for a one use walk."
				},

				new CatFood
				{
					Name = "Meow Meow Happiness",
					Price = 36.50m,
					Quantity = 42,
					Description = "Crafted out of the finest souls of the innocent. Guaranteed to satisfy your kitten.",
					KittenFood = true
				},

				new CatFood
				{
					Name = "Num Nums",
					Price = 1,
					Quantity = 0,
					Description = "Num num num num gone",
					KittenFood = false
				},
			};

		}

		private Dictionary<string, DogLeash> _dogLeashes= new Dictionary<string, DogLeash>();

		private Dictionary<string, CatFood> _catFeed = new Dictionary<string, CatFood>();

		

		

		public void AddProduct(Product product)

		{

			_products.Add(product);

			//if the product field is drawn from a DogLeash's object of dogLeash, then it goes here
			if (product is DogLeash)
			{
				/*so because the product is dogLeash, it now has every property of the dogLeash,
				the product's name is the name of the current dogLeash*/
				_dogLeashes.Add(product.Name, (DogLeash)product);
				
			}
			//if the product field is drawn from a CatFood's object of catFood, then it goes here
			else if (product is CatFood)
			{
				_catFeed.Add(product.Name, (CatFood)product);
			}
			
		}
		//The return type here is DogLeash because it is from the DogLeash class. It is then comparing the temporary string
		//name to the Dictionary's key that is contained
		public DogLeash GetDogLeashByName(string name)
		{
			try
			{
				return _dogLeashes[name];
			}
			catch (Exception ex)
			{

                return null;
                throw;
            }

		}

		public CatFood GetCatFoodByName(string name)
		{
			try
			{
				return _catFeed[name];
			}
			catch (Exception ex)
			{

                return null;
                throw;
            }
		}

		public List<string> GetOnlyInStockProducts()
		{
            return _products.InStock().Select(x => x.Name).ToList();
        }

		public decimal GetTotalPriceOfInventory()
		{
			return _products.InStock().Select(x => x.Price).Sum();
		}
	}
}
