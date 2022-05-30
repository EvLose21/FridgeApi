using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
