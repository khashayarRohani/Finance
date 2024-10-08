using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Comment;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  
    public class CommentRepository : ICommentRepository
    {
          private readonly ApplicationDbContext _context;
        
    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
        public async Task<List<Comment>> GetAllAsync(CommentQueryObject commentQueryObject)
        {
            
          var comments = _context.Comments.Include(a => a.AppUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(commentQueryObject.Symbol))
            {
                comments = comments.Where(s => s.Stock.Symbol == commentQueryObject.Symbol);
            };
            if (commentQueryObject.IsDecsending == true)
            {
                comments = comments.OrderByDescending(c => c.CreatedOn);
            }
            return await comments.ToListAsync();

        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.Include(i=>i.AppUser).FirstOrDefaultAsync(f=>f.Id==id);

            if(comment == null)
            {
                return null;
            }
            return comment;
        }
           public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(f=>f.Id==id);
            if(commentModel==null)
            { return null;}

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
           return commentModel;


        }

        public async Task<Comment> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(f=>f.Id==id);
            if(existingComment==null)
            return null;

            existingComment.Content = commentModel.Content;
            existingComment.Title=commentModel.Title;

            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}