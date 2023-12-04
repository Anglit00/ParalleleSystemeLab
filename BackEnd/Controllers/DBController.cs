using Backend;
using Backend.Models; // Add this using statement to import your Crud class
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        private readonly Crud _crud;

        public DBController(Crud crud)
        {
            _crud = crud;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var items = _crud.GetAllFood();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            // Adjust the method in your Crud class to get a single item by ID
            var item = _crud.GetFoodById(id);

            if (item == null)
            {
                return NotFound(); // Item not found
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] FoodModel model)
        {
            _crud.CreateFood(model);
            return CreatedAtAction(nameof(GetItemById), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] FoodModel model)
        {
            // Check if the item exists before updating
            var existingItem = _crud.GetFoodById(id);

            if (existingItem == null)
            {
                return NotFound(); // Item not found
            }

            _crud.UpdateFood(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            // Check if the item exists before deleting
            var existingItem = _crud.GetFoodById(id);

            if (existingItem == null)
            {
                return NotFound(); // Item not found
            }

            _crud.DeleteFood(id);
            return NoContent();
        }
    }
}
