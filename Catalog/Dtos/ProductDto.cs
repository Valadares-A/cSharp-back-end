namespace Catalo.Dtos
{
	// Pelo o que entendi, DTOs são objetos que representam um objeto de dados,
	// em outras palavras, podem ser considerados os contratos dos payloads
	public record ProductDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
		public decimal Price { get; init; }
		public DateTimeOffset CreateDate { get; init; }
	}

}