using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BE;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SALEH;Initial Catalog=Restaurant2;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // افزودن داده‌های اولیه برای نقش‌ها
            var manager = new IdentityRole("manager");
            manager.NormalizedName = "manager";

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var customer = new IdentityRole("customer");
            customer.NormalizedName = "customer";
            modelBuilder.Entity<IdentityRole>().HasData(manager, admin, customer);

           
            modelBuilder.Entity<Comment>()
                .HasOne(f => f.Reply) 
                .WithOne(fh => fh.Comment)    
                .HasForeignKey<Reply>(fh => fh.ReplyCommentId);

            modelBuilder.Entity<Food>()
         .HasOne(f => f.FoodHistory) 
         .WithOne(fh => fh.Food)    
         .HasForeignKey<FoodHistory>(fh => fh.FoodHistoryFoodId); 

        }

        public DbSet<Food> Foods{ set; get; }
        public DbSet<Menu> Menus{ set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<FoodHistory> FoodHistorys { set; get; }
        public DbSet<Recipe> Recipes { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Reply> Replys { set; get; }
    }
}