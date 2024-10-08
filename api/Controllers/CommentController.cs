using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
     [Route("/api/comment")]
    [ApiController]
   
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commetRepo;
         private readonly IStockRepository _stockRepo;

         private readonly UserManager<AppUser> _userManager;
         private readonly IFMPService _fmpService;
        public CommentController(ICommentRepository commentRepo ,IStockRepository stockRepo ,UserManager<AppUser> userManager,IFMPService fmpService)
        {
            _commetRepo=commentRepo;
            _stockRepo=stockRepo;
            _userManager =userManager;
            _fmpService = fmpService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll (){

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await _commetRepo.GetAllAsync();

            var commentDto = comments.Select(s=> s.ToCommentDto());
            return Ok(commentDto);

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commetRepo.GetByIdAsync(id);

            if(comment==null)
            {
                return NotFound();
            } 

            return Ok(comment.ToCommentDto());
        } 

        [HttpPost("{symbol:alpha}")]
        public async Task<IActionResult> Create([FromRoute] string symbol ,[FromBody] CreateCommentDto commentDto)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        var stock = await _stockRepo.GetBySymbolAsync(symbol);

            if (stock == null)
            {
               
                stock = await _fmpService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                {
                    return BadRequest("Stock does not exists");
                }
                else
                {
                    await _stockRepo.CreateAsync(stock);
                }
            }
          
            var username =  User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
             var commentModel = commentDto.ToCommentFromCreate(stock.Id);
              commentModel.AppUserId = appUser.Id;
            await _commetRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentModel = await _commetRepo.DeleteAsync(id);

            if(commentModel==null)
            {
                return NotFound("Comment does not Exist!!!");

            }
            return Ok(commentModel);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateCommentDto updateDto)
        {
                var comment = await _commetRepo.UpdateAsync(id,updateDto.ToCommentFromUpdate());
                if(comment==null)
                {
                    return NotFound("comment does not exist");
                }

            return Ok(comment.ToCommentDto());

        }
    }

  
}