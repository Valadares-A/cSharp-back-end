using Catalog.Entities;

namespace Catalog.Repositories
{
	public interface MockedProductsRepositoryInterface
	{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(Guid id);
		Task CreateProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(Guid id);
	}
}