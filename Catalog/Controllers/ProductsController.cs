using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalo.Dtos;

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
	}

}