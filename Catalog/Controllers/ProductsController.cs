using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalo.Dtos;
using Catalog.Dtos;

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
		public IEnumerable<ProductDto> GetProducts()
		{
			return _productsRepository.GetAll().Select(p => p.AsDto());
		}

		// GET api/products/{id} - get product by id
		[HttpGet("{id}")]
		// ActionResult diz pro meu metodo que eu posso ter varios retornos
		// no caso, as respostas das requests:
		// 200 - OK
		// 404 - Not Found
		// 500 - Internal Server Error
		// etc...
		public ActionResult<ProductDto> GetProductById(Guid id)
		{
			var p = _productsRepository.GetById(id);

			if (p is null)
			{
				return NotFound();
			}
			Console.WriteLine($"Product FDP: {p}");
			return p.AsDto();
		}


		// POST api/products - create a new product
		[HttpPost]
		public ActionResult<ProductDto> CreateProduct(CreateProductDto product)
		{
			Product p = new()
			{
				Id = Guid.NewGuid(),
				Name = product.Name,
				Price = product.Price,
				createDate = DateTimeOffset.UtcNow
			};
			_productsRepository.CreateProduct(p);
			return CreatedAtAction(nameof(GetProductById), new { id = p.Id }, p.AsDto());
		}

		// PUT api/products/{id} - update a product
		[HttpPut("{id}")]
		public ActionResult UpdateProduct(Guid id, UpdateProductDto product)
		{
			var p = _productsRepository.GetById(id);
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
			_productsRepository.UpdateProduct(updatedProduct);

			return NoContent();
		}


		// DELETE api/products/{id} - delete a product
		[HttpDelete("{id}")]
		public ActionResult DeleteProduct(Guid id)
		{
			var p = _productsRepository.GetById(id);
			if (p is null)
			{
				return NotFound();
			}
			_productsRepository.DeleteProduct(id);
			return NoContent();
		}
	}

}