
using ATCMediator.Mediator.Interfaces;
using ATCMediator.Mediator.Primitives;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IAtcRequestHandler<UpdateProductCommand, AtcUnit>
    {
        public async Task<AtcUnit> HandlerAsync(UpdateProductCommand request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}