using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Abstractions
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
