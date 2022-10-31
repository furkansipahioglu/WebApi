using FoodAPI.Models;
using FoodAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly taskFoodRepository _foodRepository;

        public FoodsController(taskFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await _foodRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFoods(int id)
        {
            return await _foodRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Food>>PostFoods([FromBody] Food food)
        {
            var newFood = await _foodRepository.Create(food);
            return CreatedAtAction(nameof(GetFoods), new { id = newFood.id }, newFood);
        }

        [HttpPut]
        public async Task<ActionResult> PutFoods(int id, [FromBody] Food food)
        {
            if(id != food.id)
            {
                return BadRequest();
            }

            await _foodRepository.Update(food);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var foodToDelete = await _foodRepository.Get(id);
            if (foodToDelete == null)
                return NotFound();

            await _foodRepository.Delete(foodToDelete.id);
            return NoContent();
        }
    }
}
