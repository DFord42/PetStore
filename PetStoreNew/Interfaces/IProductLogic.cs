using System;
using PetStore.Data;

namespace PetStore
{
	public interface IProductLogic
	{
		void AddProduct(ProductEntity product);
		public ProductEntity GetProductById(int productId);

    }
}

