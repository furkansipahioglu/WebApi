using FoodAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Repositories
{
    public interface taskFoodRepository
    {
        Task<IEnumerable<Food>> Get();
        Task<Food> Get(int id);
        Task<Food> Get(string name);
        Task<Food> Create(Food food);
        Task Update(Food food);
        Task Delete(int id);
    }
}
