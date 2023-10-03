using System;
namespace PetStore
{
	public interface IProductLogic
	{
		void AddProduct(Product product);
        //DogLeash GetDogLeashByName(string name);
        //CatFood GetCatFoodByName(string name);
        //DryCatFood GetDryCatFoodByName(string name);
        public T GetProductByName<T>(string name) where T : Product;

        List<string> GetOnlyInStockProducts();
		decimal GetTotalPriceOfInventory();
	}
}

