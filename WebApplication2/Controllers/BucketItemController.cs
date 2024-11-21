using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repository;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/BucketItem")]
    public class BucketItemController : Controller
    {
        private readonly IBucketItemRepository _repo;

        public BucketItemController(IBucketItemRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BucketItem item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null.");
            }

            var created = await _repo.AddAsync(item);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BucketItem item)
        {
            if (item == null || id != item.Id)
            {
                return BadRequest("Invalid item data.");
            }

            var updated = await _repo.UpdateAsync(item);
            return Ok(updated);
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkComplete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            await _repo.MarkCompleteAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}

