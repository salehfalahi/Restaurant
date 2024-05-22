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
            .Where(cb => cb.MenuId == menuId && cb.Delete == true)
            .Select(cb => new Food
            {
                Id = cb.Id,
                Name = cb.Name,
                Description = cb.Description,
                Photo = cb.Photo,
                Star = cb.Star,
                Price = cb.Price,
                MenuId = cb.MenuId

            })
                .ToListAsync();
            return Foods;
        }
        public async Task<Food> GetFoodById(int Id)
        {
            var q = from i in db.Foods where Id == i.Id select i;

            var result = await q.SingleOrDefaultAsync();

            if (result == null)
            {
                throw new Exception("غذایی پیدا نشد");
            }

            return result;
        }
        public async Task<List<Food>> ReadAsync()
        {
            return await db.Foods.ToListAsync();
        }

        public void ManageFood(Food s)
        {
            var q = from i in db.Foods where i.Id == s.Id select i;
            Food sp = new Food();
            sp = q.Single();
            sp.Id = s.Id;
            sp.Name = s.Name;
            sp.Star = s.Star;
            sp.Price = s.Price;
            sp.Description = s.Description;
            sp.Photo = s.Photo;
            sp.MenuId = s.MenuId;
            db.SaveChanges();
        }
		public async Task<List<Food>> GetFoodsByName(List<string> tags)
		{
            List<Food> Foods = new List<Food>();
            foreach (var item in tags)
            {
				var q = from i in db.Foods where i.Name.Contains(item.ToString())|| i.Description.Contains(item.ToString())
                        select i;
                Foods=Foods.Concat(q.ToList()).ToList();

			}

			return Foods;
		}
	}
}
