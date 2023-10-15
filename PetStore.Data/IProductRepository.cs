using System;
namespace PetStore.Data
{
	public interface IProductRepository
	{
        public void AddNewProduct(ProductEntity product);
        public ProductEntity Lookup(int productId);
        public IEnumerable<ProductEntity> ViewAll();

    }
}

