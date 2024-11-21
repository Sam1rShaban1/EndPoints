using WebApplication2.Models;
using System;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Repository
{
    public class BucketItemRepository : IBucketItemRepository
    {
        private readonly applicationDbContext _context;

        public BucketItemRepository(applicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BucketItem item)
        {
            await _context.bucketItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<BucketItem> FindOneAsync(int id)
        {
            return await _context.bucketItems
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(BucketItem item)
        {
            _context.bucketItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await FindOneAsync(id);
            if (item is not null)
            {
                _context.bucketItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BucketItem>> GetAllAsync()
        {
            return await _context.bucketItems
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

