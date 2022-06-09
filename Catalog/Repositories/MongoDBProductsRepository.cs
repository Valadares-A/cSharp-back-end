using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

// Repository é onde se faz a lógica de persistência
// é a conexão entre o controller e o banco de dados

namespace Catalog.Repositories
{
	public class MongoDBProductsRepository : MockedProductsRepositoryInterface
	{
		// mongo com docker: docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
		// nome da base de dados
		private const string databaseName = "catalog";
		// nome da coleção / tipode de registro / tablela
		private const string collectionName = "products";
		// Instancia uma variavel do tipo mongo referente a tabela products
		private readonly IMongoCollection<Product> _products;
		private readonly FilterDefinitionBuilder<Product> _filterBuilder = Builders<Product>.Filter;
		public MongoDBProductsRepository(IMongoClient mongoClient)
		{
			IMongoDatabase database = mongoClient.GetDatabase(databaseName);
			_products = database.GetCollection<Product>(collectionName);
		}

		public async Task CreateProductAsync(Product product)
		{
			await _products.InsertOneAsync(product);
		}

		public async Task DeleteProductAsync(Guid id)
		{
			var filter = _filterBuilder.Eq("Id", id);
			await _products.DeleteOneAsync(filter);
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await _products.Find(new BsonDocument()).ToListAsync();
		}

		public async Task<Product> GetByIdAsync(Guid id)
		{
			var filter = _filterBuilder.Eq("Id", id);
			// var filter = _filter.Eq(p => p.Id, id);
			return await _products.Find(filter).SingleOrDefaultAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			var filter = _filterBuilder.Eq("Id", product.Id);
			await _products.ReplaceOneAsync(filter, product);
		}
	}
}