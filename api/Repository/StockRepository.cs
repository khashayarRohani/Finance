using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository:IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x=>x.Id ==id);

            if(stockModel==null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return(stockModel);
        }

        public async  Task<List<Stock>>GetAllAsync(ObjectQuery query){
          var stocks=  _context.Stocks.Include(c=>c.Comments).ThenInclude(t=>t.AppUser).AsQueryable();
          if(!string.IsNullOrWhiteSpace(query.CompanyName))
          {
            stocks = stocks.Where(w=> w.CompanyName.Contains(query.CompanyName));
          }
           if(!string.IsNullOrWhiteSpace(query.Symbol))
           {
            stocks = stocks.Where(w=> w.Symbol.Contains(query.Symbol));
           }
           if(!string.IsNullOrWhiteSpace(query.SortBy))
           {
            if(query.SortBy.Equals("Symble",StringComparison.OrdinalIgnoreCase))
            {
                stocks = query.IsDecsending? stocks.OrderByDescending(o=>o.Symbol): stocks.OrderBy(o=> o.Symbol);
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
           }
          

           return await stocks.ToListAsync();
        }
       

        public async Task<Stock?> GetByIdAsync(int id)
        {
           return await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(i=> i.Id ==id);
        }

        public async Task<Stock> GetBySymbolAsync(string symbol)
        {
           return await _context.Stocks.FirstOrDefaultAsync(f=>f.Symbol==symbol);
        }

        public Task<bool> StockExist(int id)
        {
           return _context.Stocks.AnyAsync(a=>a.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
           var existingStock = await _context.Stocks.FirstOrDefaultAsync(x=>x.Id == id);
           if(existingStock==null)
           {
            return null;
           }
            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Industry = stockDto.Industry;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.MarketCap = stockDto.MarketCap;
            existingStock.LastDiv = stockDto.LastDiv;
        
            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}