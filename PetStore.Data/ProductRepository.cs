using System;
namespace PetStore.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductContext _context;

		public ProductRepository()
		{
			_context = new ProductContext();
		}

		public void AddNewProduct(ProductEntity product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public ProductEntity Lookup(int productId)
		{
			return _context.Products.SingleOrDefault(x => x.Id == productId);
		}

		public IEnumerable<ProductEntity> ViewAll()
		{
			return _context.Products;
		}
	}
}