﻿using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Abstractions
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
