using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BucketItem
    {
        [Key]
        public int Id { get; set; }
        public string? CountryName { get; set; }
        public string? CityName { get; set; }
        public decimal Budget { get; set; }
        public bool IsComplete { get; set; }
    }
}