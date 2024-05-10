using BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class daFood
    {
        AppDbContext db = new AppDbContext();

        public void Create(Food s)
        {
            db.Foods.Add(s);
            db.SaveChanges();
        }
        public async Task<List<Food>> GetFoodsByMenuId(int menuId)
        {
            var Foods = await db.Foods
            .Where(cb => cb.MenuId == menuId)
            .Select(cb => new Food
            {
                Id = cb.Id,
                Name = cb.Name,
                Description = cb.Description,
                Photo = cb.Photo,
                Price = cb.Price

            })
                .ToListAsync();
            return Foods;
        }
    }
}
