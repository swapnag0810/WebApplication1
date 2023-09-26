using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SampleDBContext: DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = null!;
    }
}
