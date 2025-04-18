
using ATCMediator.Mediator.Interfaces;
using ATCMediator.Mediator.Primitives;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IAtcRequest<AtcUnit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    }
}