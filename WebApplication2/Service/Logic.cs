using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Service
{
    public class LogicService
    {
        private readonly IBucketItemRepository _repository;

        public LogicService(IBucketItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<BucketItem> CreateAsync(BucketItem bucketItem)
        {
            return await _repository.AddAsync(bucketItem);
        }

        public async Task<BucketItem> FindOneAsync(int id)
        {
            return await _repository.FindOneAsync(id);
        }

        public async Task<BucketItem> UpdateAsync(BucketItem bucketItem)
        {
            var existing = await FindOneAsync(bucketItem.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            return await _repository.UpdateAsync(bucketItem);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await FindOneAsync(id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            await _repository.DeleteAsync(id);
        }

        public async Task<BucketItem[]> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}

