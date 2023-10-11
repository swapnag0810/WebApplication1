using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private SampleDBContext _sampleContext;
        private IThirdPartyHolidayService thirdPartyHolidaySvc ;

        public ProductsController(ILogger<ProductsController> logger, SampleDBContext sampleContext, IThirdPartyHolidayService thirdPartyHoliday)
        {
            _logger = logger;
            _sampleContext = sampleContext;
            thirdPartyHolidaySvc = thirdPartyHoliday;
        }

        // GET: api/<ProductsController>/GetProducts
        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product>? GetProducts()
        {
            try
            {


                _logger.LogInformation("Get Products page visited at {DT}",
                 DateTime.UtcNow.ToLongTimeString());

                return _sampleContext.Products;
            }
            catch(Exception ex)
            {
                //_logger.LogWarning(MyLogEvents.GetItemNotFound, "Get Products NOT FOUND");
                return null;
            }
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<ThirdPartyHoliday>> GetHolidays()
        {
            //return (IEnumerable<ThirdPartyHoliday>)thirdPartyHolidaySvc.GetHolidays("US", 2023);
            List<ThirdPartyHoliday> holidays = new List<ThirdPartyHoliday>();
            holidays = await thirdPartyHolidaySvc.GetHolidays("US", 2023);
            return holidays;
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

