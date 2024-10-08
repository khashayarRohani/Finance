using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(ObjectQuery query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> GetBySymbolAsync(string symbol);
        Task<Stock> CreateAsync (Stock stockModel);
        Task<Stock?> UpdateAsync(int id,UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExist(int id);
    }
}