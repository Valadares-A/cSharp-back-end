using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly MockedProductsRepository _productsRepository;

		// public ProductsController(MockedProductsRepository productsRepository)
		// {
		// 	_productsRepository = productsRepository;
		// }

		public ProductsController()
		{
			_productsRepository = new MockedProductsRepository();
		}

		// GET api/products - get all products
		[HttpGet]
		public IEnumerable<Product> GetProducts()
		{
			return _productsRepository.GetAll();
		}

		// GET api/products/{id} - get product by id
		[HttpGet("{id}")]
		// ActionResult diz pro meu metodo que eu posso ter varios retornos
		// no caso, as respostas das requests:
		// 200 - OK
		// 404 - Not Found
		// 500 - Internal Server Error
		// etc...
		public ActionResult<Product> GetProductById(Guid id)
		{
			var p = _productsRepository.GetById(id);
			Console.WriteLine($"Product FDP: {p}");
			if (p is null)
			{
				return NotFound();
			}
			return p;
		}
	}

}