using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RetailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This routes requests to: api/values
    public class ValuesController : ControllerBase
    {
        // Simple in-memory list to serve as our temporary mock database
        private static readonly List<string> _items = new List<string> { "Inventory Item A", "Inventory Item B" };

        // 1. GET: api/values (Retrieve all items)
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_items); // Returns Status 200 OK with the array
        }

        // 2. GET: api/values/0 (Retrieve specific item by index)
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= _items.Count)
            {
                return BadRequest("Invalid index position requested."); // Returns Status 400
            }
            return Ok(_items[id]);
        }

        // 3. POST: api/values (Create/Insert a new record)
        [HttpPost]
        public ActionResult Post([FromBody] string newItem)
        {
            if (string.IsNullOrEmpty(newItem))
            {
                return BadRequest("Item value cannot be empty.");
            }
            _items.Add(newItem);
            return Ok("Item added successfully.");
        }

        // 4. PUT: api/values/0 (Update an existing record)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string updatedItem)
        {
            if (id < 0 || id >= _items.Count)
            {
                return NotFound("The requested item does not exist."); // Returns Status 404
            }
            _items[id] = updatedItem;
            return Ok("Item updated successfully.");
        }

        // 5. DELETE: api/values/0 (Remove a record)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _items.Count)
            {
                return NotFound();
            }
            _items.RemoveAt(id);
            return Ok("Item deleted successfully.");
        }
    }
}