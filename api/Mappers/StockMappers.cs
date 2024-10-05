using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStackDto(this Stock stockModel){


            return new StockDto 
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(s=> s.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStackFromCreateDto(this CreateStockRequestDto stockDeto )
        {
            return new Stock{
                 Symbol = stockDeto.Symbol,
                CompanyName = stockDeto.CompanyName,
                Purchase = stockDeto.Purchase,
                LastDiv = stockDeto.LastDiv,
                Industry = stockDeto.Industry,
                MarketCap = stockDeto.MarketCap

            };
        }
    }
}