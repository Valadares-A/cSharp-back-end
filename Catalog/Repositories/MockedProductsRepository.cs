using Catalog.Entities;
namespace Catalog.Repositories
{
	public class MockedProductsRepository : MockedProductsRepositoryInterface
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

		public async Task CreateProductAsync(Product product)
		{
			products.Add(product);
			await Task.CompletedTask;
		}

		public async Task DeleteProductAsync(Guid id)
		{
			var index = products.FindIndex(p => p.Id == id);
			products.RemoveAt(index);
			await Task.CompletedTask;
		}

		// public IEnumerable<Product> GetAll() => products;
		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await Task.FromResult(products);
		}

		public async Task<Product> GetByIdAsync(Guid id)
		{
			// return products.FirstOrDefault(p => p.Id == id);
			var product = products.Where(p => p.Id == id).SingleOrDefault();
			return await Task.FromResult(product);
		}

		public async Task UpdateProductAsync(Product product)
		{
			var index = products.FindIndex(p => p.Id == product.Id);
			products[index] = product;
			await Task.CompletedTask;
		}
	}
}