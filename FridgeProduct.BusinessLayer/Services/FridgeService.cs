using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeProduct.BusinessLayer.Interfaces;
using FridgeProduct.BusinessLayer.Models;
using FridgeProduct.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FridgeProduct.BusinessLayer.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _repository;
        public FridgeService(IRepositoryManager repository)
        {
            _repository = repository.Fridge;
        }

        public async Task<FridgeList> GetFridgeListAsync()
        {
            var fridges = await _repository.GetAllFridgesQuery(trackChanges:false).
                Select(l => new FridgeListitem
                {
                    Id = l.Id,
                    Name = l.Name,
                    Model = l.FridgeModel.Name
                }).ToListAsync();

            return new FridgeList() { FridgesList = fridges };
        }

        public async Task<PaginatedList<FridgeListitem>> GetFridgeListAsync1(int? pageNumber)
        {
            var fridges = _repository.GetAllFridgesQuery(trackChanges: false).
                Select(l => new FridgeListitem
                {
                    Id = l.Id,
                    Name = l.Name,
                    Model = l.FridgeModel.Name
                });

            return await PaginatedList<FridgeListitem>.CreateAsync(fridges, pageNumber??1, 3);
        }
    }
}
