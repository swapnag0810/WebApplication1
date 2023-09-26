namespace WebApplication1.Seeds
{
    using System.Linq;
    using WebApplication1.Models;


    public static class ProductSeed
    {
        public static void Seed(this SampleDBContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.Add(new Product
                {
                    Id = 1,
                    Name = "Test Product 1",
                    Price = 22.50m,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });
                dbContext.Products.Add(new Product
                {
                    Id = 2,
                    Name = "Test Product 2",
                    Price = 60.50m,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });
                dbContext.Products.Add(new Product
                {
                    Id = 3,
                    Name = "Test Product 3",
                    Price =50.50m,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });

                dbContext.SaveChanges();
            }
        }
    }
}
