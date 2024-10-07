using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
     [Route("/api/comment")]
    [ApiController]
   
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commetRepo;
         private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo ,IStockRepository stockRepo)
        {
            _commetRepo=commentRepo;
            _stockRepo=stockRepo;
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

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId ,[FromBody] CreateCommentDto commentDto)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!await _stockRepo.StockExist(stockId))
            {
                return BadRequest("Stock Does Not Exist!!!");
            }
             var commentModel = commentDto.ToCommentFromCreate(stockId);
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