using Catalo.Dtos;
using Catalog.Entities;

namespace Catalog
{
	public static class Extensions
	{
		// pelo o que entendi, o this aqui recebe direto o contexto da classe do objeto
		// evitando todo o esquema de ter que estanciar essa classe pra chamar esse metodo
		public static ProductDto AsDto(this Product product)
		{
			return new ProductDto
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				CreateDate = product.createDate
			};
		}
	}
}