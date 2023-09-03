using System;
namespace PetStore
{
	public interface IProductLogic
	{
		void AddProduct(Product product);
		DogLeash GetDogLeashByName(string name);
		CatFood GetCatFoodByName(string name);
		List<string> GetOnlyInStockProducts();
		decimal GetTotalPriceOfInventory();
	}
}

