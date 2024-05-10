using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BE
{
    public class AppUser : IdentityUser
    { 
      
        public List<Reply> Replies { get; set; } = new List<Reply>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Order> Orders { get; set; }= new List<Order>();
        public List<Recipe> Recipes { get; set; }= new List<Recipe>();
        public List<FoodHistory> FoodHistories { get; set; } = new List<FoodHistory>();
        public List<Basket> Baskets { get; set; }=new List<Basket>();
     
    }

    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public Reply Reply { get; set; }
        [ForeignKey("CommentReplyId")]
        public int CommentReplyId { get; set; }
        public string? Content { get; set; }
        public bool IsApproved { get; set; }
        public bool FadeComment { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("CommentUserId")]
        public int CommentUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Food Food { get; set; }
        [ForeignKey("CommentFoodId")]
        public int CommentFoodId { get; set; }
    }

    public class Reply
    {
        [Key]
        public int Id { get; set; }
        public bool IsManager { get; set; }
        public string? Content { get; set; }
        [ForeignKey("ReplyUserId")]
        public int ReplyUserId { get; set; }
        public AppUser AppUser { get; set; }
        [ForeignKey("ReplyCommentId")]
        public int ReplyCommentId { get; set; }
        public Comment Comment { get; set; }
        public DateTime DateTime { get; set; }
 
    }
   
}