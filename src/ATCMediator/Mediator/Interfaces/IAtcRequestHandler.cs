
namespace ATCMediator.Mediator.Interfaces
{
    public interface IAtcRequestHandler<in TAtcRequest, TResult> where TAtcRequest : IAtcRequest<TResult>
    {
        Task<TResult> HandlerAsync(TAtcRequest request, CancellationToken cancellationToken = default);
    }
}