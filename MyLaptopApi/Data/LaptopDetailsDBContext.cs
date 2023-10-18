using Microsoft.EntityFrameworkCore;
using MyLaptopApi.Model;

namespace MyLaptopApi.Data 
{
    public class LaptopDetailsDBContext : DbContext
    {
        public LaptopDetailsDBContext(DbContextOptions<LaptopDetailsDBContext> options) : base(options) { }
        public DbSet<LaptopDetails> LaptopDetails { get; set;}
    }
}
