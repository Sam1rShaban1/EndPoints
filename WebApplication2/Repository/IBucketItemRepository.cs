using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IBucketItemRepository
    {
        Task<IEnumerable<BucketItem>> GetAllAsync();
        Task AddAsync(BucketItem item);
        Task UpdateAsync(BucketItem item);
        Task DeleteAsync(BucketItem item);
        Task MarkAsCompleteAsync(BucketItem item);
        Task FindOneAsync(BucketItem item);
    }
}
