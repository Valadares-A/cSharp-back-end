using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalo.Dtos;
using Catalog.Dtos;

// controller é onde se cria a definição das requests
// rotas de get post put delete

namespace Catalog.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly MockedProductsRepositoryInterface _productsRepository;

		// Inject the mocked products repository (injeção de dependencias)
		// Quando a um necessidade de injeção de dependencia, se cria uma interface das classes para fazer essa injeção
		public ProductsController(MockedProductsRepositoryInterface productsRepository)
		{
			_productsRepository = productsRepository;
			// ou:
			// this._productsRepository = productsRepository;
		}

		// GET api/products - get all products
		[HttpGet]
		public async Task<IEnumerable<ProductDto>> GetProducts()
		{
			return (await _productsRepository.GetAllAsync()).Select(p => p.AsDto());
		}

		// GET api/products/{id} - get product by id
		[HttpGet("{id}")]
		// ActionResult diz pro meu metodo que eu posso ter varios retornos
		// no caso, as respostas das requests:
		// 200 - OK
		// 404 - Not Found
		// 500 - Internal Server Error
		// etc...
		public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
		{
			var p = await _productsRepository.GetByIdAsync(id);

			if (p is null)
			{
				return NotFound();
			}
			Console.WriteLine($"Product FDP: {p}");
			return p.AsDto();
		}


		// POST api/products - create a new product
		[HttpPost]
		public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto product)
		{
			Product p = new()
			{
				Id = Guid.NewGuid(),
				Name = product.Name,
				Price = product.Price,
				createDate = DateTimeOffset.UtcNow
			};
			await _productsRepository.CreateProductAsync(p);
			return CreatedAtAction(nameof(GetProductById), new { id = p.Id }, p.AsDto());
		}

		// PUT api/products/{id} - update a product
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateProduct(Guid id, UpdateProductDto product)
		{
			var p = await _productsRepository.GetByIdAsync(id);
			if (p is null)
			{
				return NotFound();
			}

			// with-expression
			// ele cria uma copia do objeto p e atualiza os valores
			// e joga pra dentro do updateProduct
			Product updatedProduct = p with
			{
				Name = product.Name,
				Price = product.Price,
			};
			await _productsRepository.UpdateProductAsync(updatedProduct);

			return NoContent();
		}


		// DELETE api/products/{id} - delete a product
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteProduct(Guid id)
		{
			var p = await _productsRepository.GetByIdAsync(id);
			if (p is null)
			{
				return NotFound();
			}
			await _productsRepository.DeleteProductAsync(id);
			return NoContent();
		}
	}

}