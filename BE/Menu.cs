using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Food> Foods { get; set; } = new List<Food>();
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
        public string? Photo { get; set; }
        public int Price { get; set; }
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

 
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public bool TakeOut { get; set; }
        public List<Food> Items { get; set; } = new List<Food>();
        [ForeignKey("OrderUserId")]
        public int OrderUserId { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("OrderBasketId")]
        public int OrderBasketId { get; set; }
        public Basket Basket { get; set; }

        public double Price { get; set; }
        public string Time { get; set; }
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
