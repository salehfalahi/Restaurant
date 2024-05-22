using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class blFood
    {
        public void Create(Food m)
        {
            daFood Food = new daFood();
            Food.Create(m);
        }
        public async Task<List<Food>> GetFoodsByMenuId(int m)
        {
            daFood Food = new daFood();
            return await Food.GetFoodsByMenuId(m);
        }
        public async Task<Food> GetFoodById(int m)
        {
            daFood Food = new daFood();
            return await Food.GetFoodById(m);
        }
        public async Task<List<Food>> ReadAsync()
        {
            daFood Food = new daFood();
            return await Food.ReadAsync();
        }  
        public async Task<List<Food>> GetFoodsByName(List<string>tag)
        {
            daFood Food = new daFood();
            return await Food.GetFoodsByName(tag);
        }

        public void ManageFood(Food m)
        {
            daFood Food = new daFood();
            Food.ManageFood(m);
        }

    }
}
