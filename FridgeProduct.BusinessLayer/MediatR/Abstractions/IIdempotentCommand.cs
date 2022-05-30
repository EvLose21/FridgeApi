using System;

namespace FridgeProduct.BusinessLayer.MediatR.Abstractions
{
    public interface IIdempotentCommand<out TResponse> : ICommand<TResponse>
    {
        Guid RequestId { get; set; }
    }
}
