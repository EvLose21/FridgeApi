using FridgeProduct.Contracts;
using FridgeProduct.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IFridgeRepository _fridgeRepository;
        private IFridgeModelRepository _fridgeModelRepository;
        private IProductRepository _productRepository;
        private IFridgeToProductRepository _fridgeToProductRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                    _fridgeRepository = new FridgeRepository(_repositoryContext);

                return _fridgeRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);

                return _productRepository;
            }
        }

        public IFridgeModelRepository FridgeModel
        {
            get
            {
                if (_fridgeModelRepository == null)
                    _fridgeModelRepository = new FridgeModelRepository(_repositoryContext);

                return _fridgeModelRepository;
            }
        }

        public IFridgeToProductRepository FridgeToProduct
        {
            get
            {
                if (_fridgeToProductRepository == null)
                    _fridgeToProductRepository = new FridgeToProductRepository(_repositoryContext);

                return _fridgeToProductRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
