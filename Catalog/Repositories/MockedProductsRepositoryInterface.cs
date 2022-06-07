using Catalog.Entities;

namespace Catalog.Repositories
{
	public interface MockedProductsRepositoryInterface
	{
		IEnumerable<Product> GetAll();
		Product GetById(Guid id);
	}
}