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
        daFood Food = new daFood();
        public void Create(Food m)
        {
          
            Food.Create(m);
        }
        public async Task<List<Food>> GetFoodsByMenuId(int m)
        {
            
            return await Food.GetFoodsByMenuId(m);
        }
        public async Task<Food> GetFoodById(int m)
        {
            
            return await Food.GetFoodById(m);
        }
        public async Task<List<Food>> ReadAsync()
        {
          
            return await Food.ReadAsync();
        }  
        public async Task<List<Food>> GetFoodsByName(List<string>tag)
        {
         
            return await Food.GetFoodsByName(tag);
        }

        public void ManageFood(Food m)
        {
          
            Food.ManageFood(m);
        }

    }
}
