using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
	public record CreateProductDto
	{
		// Anotations
		[Required]
		public string Name { get; init; }
		[Required]
		[Range(0, 100)]
		public decimal Price { get; init; }
	}
}