using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/api/stock")]
    [ApiController]
    public class StockController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
          private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDbContext context,IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
           var stocks = await _stockRepo.GetAllAsync();
           var stockDto = stocks.Select(s=> s.ToStackDto());

           return Ok(stockDto);
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute]int id) // extract string out and turn into int
        {
            var stock = await _stockRepo.GetByIdAsync(id);



        if(stock==null)
        {
            return NotFound();
        }

            return Ok(stock.ToStackDto());
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var modelStock = stockDto.ToStackFromCreateDto();

          await _stockRepo.CreateAsync(modelStock);
            return CreatedAtAction(nameof(GetById),new {id = modelStock.Id},modelStock.ToStackDto());

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto )
        {

            var stockModel = await _stockRepo.UpdateAsync(id,updateDto);
            if(stockModel==null)
            {
                return NotFound();
            }

           
         

            return Ok(stockModel.ToStackDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var modelStock =await _stockRepo.DeleteAsync(id);
            if(modelStock==null)
            {
                return NotFound();
            }
           

            return NoContent();
        }
        
    }
}