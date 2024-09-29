using BE;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant2.Models
{

    public class Reservation
    {
        [Required(ErrorMessage = "نام شما الزامی است.")]
        [StringLength(100, ErrorMessage = "نام نمی‌تواند بیشتر از 100 کاراکتر باشد.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "شماره تماس الزامی است.")]
        [Phone(ErrorMessage = "لطفاً یک شماره تماس معتبر وارد کنید.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "تعداد نفرات الزامی است.")]
        public int PersonCount { get; set; }

        [Required(ErrorMessage = "تاریخ الزامی است.")]
        [DataType(DataType.Date)]
        public string? ReservationDate { get; set; }

        [Required(ErrorMessage = "ساعت الزامی است.")]
        [DataType(DataType.Time)]
        public string? ReservationTime { get; set; }

        [StringLength(500, ErrorMessage = "توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد.")]
        public string Message { get; set; }
    }
    public class BasketOrder
    {
        public BE.Food Food { get; set; }
        public byte Count { get; set; }
        public double Price { get; set; }
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
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Food> Items { get; set; } = new List<Food>();
    }
    public class Basket
    {
        [Key]
        public int Id { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public bool Erased { get; set; }

        [ForeignKey("BasketUserId")]
        public int BasketUserId { get; set; }
        public AppUser User { get; set; }
    }
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Photo { get; set; }
        public string? Price { get; set; }
        public int? SpecialPrice { get; set; }
        public float? Star { get; set; }
        public bool IsSpecial { get; set; }

        public bool Delete { get; set; } = true;

        [ForeignKey("MenuId")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("FoodHistoryId")]
        public int FoodHistoryId { get; set; }
        public FoodHistory? FoodHistory { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public Order Order { get; set; }

    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public byte? Count { get; set; }
        public int FoodId { get; set; }
        public Food? Food { get; set; }

        [ForeignKey("OrderBasketId")]
        public int OrderBasketId { get; set; }
        public Basket? Basket { get; set; }

        public double Price { get; set; }
     
    
    }

    public class FoodHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [ForeignKey("FoodHistoryFoodId")]
        public int FoodHistoryFoodId { get; set; }
        public Food Food { get; set; }
        [ForeignKey("FoodHistoryChefId")]
        public int FoodHistoryChefId { get; set; }
        public AppUser User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string Text { get; set; }
    }
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
        [ForeignKey("RecipeWriterId")]
        public int RecipeWriterId { get; set; }
        public AppUser User { get; set; }


        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string Description { get; set; }
        public string Text { get; set; }
    }
}
