
using ATCMediator.Mediator.Interfaces;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IAtcRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> HandlerAsync(CreateProductCommand request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}