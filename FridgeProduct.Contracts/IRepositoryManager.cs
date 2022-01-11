﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProduct.Contracts
{
    public interface IRepositoryManager
    {
        IFridgeRepository Fridge { get; }
        IProductRepository Product { get; }
        IFridgeModelRepository FridgeModel { get; }
        IFridgeToProductRepository FridgeToProduct { get; }
        void Save();
    }
}
