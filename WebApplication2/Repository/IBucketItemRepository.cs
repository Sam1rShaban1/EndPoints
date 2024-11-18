using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IBucketItemRepository
    {
        Task<IEnumerable<BucketItem>> GetAllAsync();
        Task AddAsync(BucketItem item);
    }
}
