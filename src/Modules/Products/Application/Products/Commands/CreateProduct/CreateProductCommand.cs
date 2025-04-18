
using ATCMediator.Mediator.Interfaces;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IAtcRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<Guid>? CategoryIds { get; set; }
        public List<string>? Images { get; set; }
    }
}