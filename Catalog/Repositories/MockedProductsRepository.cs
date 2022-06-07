
using Catalog.Entities;
namespace Catalog.Repositories
{
	public class MockedProductsRepository
	{
		private readonly List<Product> products = new()
		{
			new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 10, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 20, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 3", Price = 30, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 4", Price = 40, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 5", Price = 50, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 6", Price = 60, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 7", Price = 70, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 8", Price = 80, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 9", Price = 90, createDate = DateTimeOffset.UtcNow },
			new Product { Id = Guid.NewGuid(), Name = "Product 10", Price = 100, createDate = DateTimeOffset.UtcNow },
		};

		// public IEnumerable<Product> GetAll() => products;
		public IEnumerable<Product> GetAll()
		{
			return products;
		}

		public Product GetById(Guid id)
		{
			// return products.FirstOrDefault(p => p.Id == id);
			return products.Where(p => p.Id == id).SingleOrDefault();
		}
	}
}