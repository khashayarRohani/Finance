using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public CommentController(ICommentRepository commentRepo)
        {
            _commetRepo=commentRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll (){
            var comments = await _commetRepo.GetAllAsync();

            var commentDto = comments.Select(s=> s.ToCommentDto());
            return Ok(commentDto);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var comment = await _commetRepo.GetByIdAsync(id);

            if(comment==null)
            {
                return NotFound();
            } 

            return Ok(comment.ToCommentDto());
        } 
    }

  
}