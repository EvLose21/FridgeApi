using System;
using System.Threading;
using System.Threading.Tasks;
using FridgeProduct.Contracts;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Products.Commands
{
    public record DeleteProductCommand(Guid Id) : IRequest<Unit>;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IRepositoryManager _repository;

        public DeleteProductCommandHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.Product.GetProductAsync(request.Id, trackChanges: true);

            _repository.Product.Delete(product);
            await _repository.SaveAsync();
            return Unit.Value;
        }
    }
}
