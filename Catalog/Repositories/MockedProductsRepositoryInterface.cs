using Catalog.Entities;

namespace Catalog.Repositories
{
	public interface MockedProductsRepositoryInterface
	{
		IEnumerable<Product> GetAll();
		Product GetById(Guid id);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(Guid id);
	}
}