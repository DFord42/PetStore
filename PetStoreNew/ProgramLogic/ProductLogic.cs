using System;
using PetStore.Data;
using PetStore.Validator;

namespace PetStore
{
	public class ProductLogic : IProductLogic

	{
		private List<Product> _products;

		private readonly IProductRepository _repository;
		

		public ProductLogic(IProductRepository productRepository)

		{
			_repository = productRepository;
        }


		public void AddProduct(ProductEntity product)

		{
            _repository.AddNewProduct(product);
		}

        public ProductEntity GetProductById(int productId)
        {
			return _repository.Lookup(productId);
        }
	}
}
