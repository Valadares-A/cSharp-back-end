using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
	public record UpdateProductDto
	{
		// [Required]
		// public Guid Id { get; init; }
		[Required]
		public string Name { get; init; }
		[Required]
		[Range(0, 100)]
		public decimal Price { get; init; }
	}
}