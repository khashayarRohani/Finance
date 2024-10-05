using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto (this Comment commentModel){

        return new CommentDto{
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            StockId = commentModel.StockId,
            CreatedOn=commentModel.CreatedOn
        };

        }

         public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };
        }
        
    }
}