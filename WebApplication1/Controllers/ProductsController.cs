using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<ProductsController> _logger;
        private SampleDBContext _sampleContext;

        public ProductsController(ILogger<ProductsController> logger, SampleDBContext sampleContext)
        {
            _logger = logger;
            _sampleContext = sampleContext;
        }

        // GET: api/<ProductsController>/GetProducts
        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _sampleContext.Products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _sampleContext.Products.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _sampleContext.Products.Add(value);
            _sampleContext.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var updateProduct = _sampleContext.Products.FirstOrDefault(s => s.Id == id);
            if (updateProduct != null)
            {
                _sampleContext.Entry<Product>(updateProduct).CurrentValues.SetValues(value);
                _sampleContext.SaveChanges();
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var prd = _sampleContext.Products.FirstOrDefault(s => s.Id == id);
            if (prd != null)
            {
                _sampleContext.Products.Remove(prd);
                _sampleContext.SaveChanges();
            }
        }
    }

        
}

