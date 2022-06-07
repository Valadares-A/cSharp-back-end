namespace Catalog.Entities
{
	public record Product
	{
		// init ao inves de set, permite que eu crie valores somente no momento de construção/inicialização do objeto
		// ao inves de usar 'private set'
		public Guid Id { get; init; }
		public string Name { get; init; }
		public DateTimeOffset createDate { get; init; }
		public decimal Price { get; init; }
	}
}