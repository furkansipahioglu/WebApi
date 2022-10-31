using FoodAPI.Repositories;
using FoodAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Repositories
{
    public class FoodRepository : taskFoodRepository
    {
        private readonly FoodContext _context;

        public FoodRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<Food> Create(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return food;
        }

        public async Task Delete(int id)
        {
            var foodToDelete = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(foodToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Food>> Get()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> Get(int id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task Update(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
