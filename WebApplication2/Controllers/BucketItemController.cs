using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [Route("api/[BucketItem]")]
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
    }
}
