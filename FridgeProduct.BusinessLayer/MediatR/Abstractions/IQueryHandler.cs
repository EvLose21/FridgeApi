﻿using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Abstractions
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}
