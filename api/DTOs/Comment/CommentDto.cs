using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment
{
    public class CommentDto
    {
          public int Id { get; set; }

          [Required]
          [MinLength(5,ErrorMessage ="Title must be more than 5 characters")]
          [MaxLength(280,ErrorMessage ="Title cannot be over than 280 characters")]
        public string Title { get; set; }=string.Empty;
          [Required]
          [MinLength(5,ErrorMessage ="Content must be more than 5 characters")]
          [MaxLength(280,ErrorMessage ="Content cannot be over than 280 characters")]
         public string Content { get; set; }=string.Empty;
         public DateTime CreatedOn {get; set;}= DateTime.Now;
        public int? StockId { get; set; }
    }
}