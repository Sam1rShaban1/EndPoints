using System;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class applicationDbContext:DbContext
    {
        public applicationDbContext(DbContextOptions<applicationDbContext> options) : base(options) { }
        public DbSet<BucketItem>? bucketItems { get; set; }
    }
}
